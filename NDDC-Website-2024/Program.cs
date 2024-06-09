using FluentValidation;
using FluentValidation.AspNetCore;
using NddcWebsiteLibrary.Data.CloudStorage;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Data.IReport;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Databases;
using NddcWebsiteLibrary.Model.IReport;
using NddcWebsiteLibrary.Model.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddTransient<IValidator<MyIReportModel>, IReportValidator>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IHomeData, SqlHome>();
builder.Services.AddTransient<IProjectsData, SqlProjects>();
builder.Services.AddTransient<IReportData, SqlIReport>();
builder.Services.AddTransient<ICloudStorage, AWSCloudStorage>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.MapRazorPages();

app.Run();
