using EFCore_Lib.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using NDDC_Website_2024.Validators;
using NddcWebsiteLibrary.Data.CloudStorage;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Data.IReport;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Databases;
using NddcWebsiteLibrary.Model.IReport;
using NddcWebsiteLibrary.Model.Validators;

var builder = WebApplication.CreateBuilder(args);

// Render (and any reverse proxy) terminates TLS and forwards to us over plain HTTP.
// Without this, UseHttpsRedirection below cannot see the original scheme and
// either no-ops or produces a redirect loop.
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor
                             | ForwardedHeaders.XForwardedProto
                             | ForwardedHeaders.XForwardedHost;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddTransient<IValidator<MyIReportModel>, EyeReportValidator>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddHttpClient("PmisApi", client =>
{
    var baseUrl = builder.Configuration["PmisApi:BaseUrl"] ?? "https://pmis-2026-ayf5gnhzgdb4d9dt.westeurope-01.azurewebsites.net/api/projects/";
    client.BaseAddress = new Uri(baseUrl);
    var apiKey = builder.Configuration["PmisApi:ApiKey"];
    if (!string.IsNullOrEmpty(apiKey))
    {
        client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
    }
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("User-Agent", "curl/8.4.0");
});
builder.Services.AddTransient<IProjectsData, ApiProjects>();
builder.Services.AddTransient<IHomeData, SqlHome>();
builder.Services.AddTransient<IReportData, SqlIReport>();
builder.Services.AddTransient<ICloudStorage, AWSCloudStorage>();
builder.Services.AddDbContext<NDDCWebsiteContext>(options =>
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("SqlDb"))
    );

// The container filesystem is ephemeral: every Render deploy or restart wipes
// ~/.aspnet/DataProtection-Keys, which mints a brand-new key ring. Any
// antiforgery cookie already in a user's browser can then no longer be
// decrypted, and the next POST fails with "The key {...} was not found in the
// key ring". Persisting the key ring to the database keeps it stable across
// deploys and lets every instance share it.
//
// This only affects antiforgery/session cookies — no user data is encrypted
// with these keys yet — so an already-lost key ring needs no migration: users
// simply get a fresh cookie on their next page load.
//
// NOTE: this deliberately reuses the SqlDb connection, not PMIS.
builder.Services.AddDataProtection()
    .PersistKeysToDbContext<NDDCWebsiteContext>()
    .SetApplicationName("NDDC-Website-2024");

var app = builder.Build();

// Automatically ensure DataProtectionKeys table exists for ASP.NET Core Data Protection
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<NDDCWebsiteContext>();
        db.Database.ExecuteSqlRaw(@"
            IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[DataProtectionKeys]'))
            BEGIN
                CREATE TABLE [dbo].[DataProtectionKeys] (
                    [Id]           INT IDENTITY (1, 1) NOT NULL,
                    [FriendlyName] NVARCHAR (512)   NULL,
                    [Xml]          NVARCHAR (MAX)     NOT NULL,
                    CONSTRAINT [PK_DataProtectionKeys] PRIMARY KEY CLUSTERED ([Id] ASC)
                );
            END");
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogWarning(ex, "Could not ensure DataProtectionKeys table exists at startup. If DataProtectionKeys table is missing, run NDDC_Patch_002_DataProtectionKeys.sql.");
    }
}

// Configure the HTTP request pipeline.
app.UseForwardedHeaders();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Liveness probe. Deliberately does NOT touch the database: Render restarts the
// container on a failed health check, and we do not want a database blip to
// trigger a restart loop of an otherwise-healthy web process.
app.MapGet("/healthz", () => "OK").AllowAnonymous();

app.MapRazorPages();

app.MapGet("/images/projects/{imageId:int}", async (int imageId, IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("PmisApi");
    var response = await client.GetAsync($"images/{imageId}");
    if (!response.IsSuccessStatusCode) return Results.NotFound();
    var stream = await response.Content.ReadAsStreamAsync();
    var contentType = response.Content.Headers.ContentType?.ToString() ?? "image/jpeg";
    return Results.Stream(stream, contentType);
});

app.Run();
