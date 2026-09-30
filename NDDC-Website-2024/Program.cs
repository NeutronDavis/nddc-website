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
builder.Services.AddTransient<IHomeData, SqlHome>();
builder.Services.AddTransient<IProjectsData, SqlProjects>();
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

app.Run();
