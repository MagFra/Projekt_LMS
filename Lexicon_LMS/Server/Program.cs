using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Lexicon_LMS.Server.Data;
using Lexicon_LMS.Server.Extensions;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Server.Models.Profiles;
using Lexicon_LMS.Server.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddIdentityServer()
//    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(
//    options =>
//    {
//        options.IdentityResources["openid"].UserClaims.Add("role");
//        options.ApiResources.Single().UserClaims.Add("role");
//    }
//    );

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(

        options => {

            options.IdentityResources["openid"].UserClaims.Add("role");

            if (options.ApiResources.Any())
            {
                options.ApiResources.Single().UserClaims.Add("role");
            }
        });

builder.Services.AddAutoMapper(typeof(ActivitiesMapperProfile));
builder.Services.AddAutoMapper(typeof(AssignmentsMapperProfile));
builder.Services.AddAutoMapper(typeof(CoursesMapperProfile));
builder.Services.AddAutoMapper(typeof(ModulesMapperProfile));
builder.Services.AddAutoMapper(typeof(UsersMapperProfile));

builder.Services.AddScoped<IModuleService, ModuleService>();

//builder.Services.AddAuthentication()
//    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.SeedDataAsync();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");


app.Run();

