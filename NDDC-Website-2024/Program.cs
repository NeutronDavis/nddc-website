using EFCore_Lib.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
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
