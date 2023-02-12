using BeitragRdrBlazorServerApp.Data;
using BeitragRdrBlazorServerApp.Policies;
using BeitragRdrDataAccessLibrary.Data;
using BeitragRdrDataAccessLibrary.Repo;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace BeitragRdrBlazorServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();

            builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IDataAccess, DataAccess>();
            builder.Services.AddSingleton<ClientPolicies>(new ClientPolicies());

            builder.Services.AddScoped<IBeitragRepo, BeitragRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

            //builder.Services.AddVersionedApiExplorer().AddMicrosoftIdentityConsentHandler();

            builder.Services.AddApiVersioning();


            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

            builder.Services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim("jobTitle", "Admin");
                });
                opt.AddPolicy("Customer", policy =>
                {
                    policy.RequireClaim("jobTitle", "Customer");
                });
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRewriter(
                new RewriteOptions().Add(
                    context =>
                    {
                        if(context.HttpContext.Request.Path == "/MicrosoftIdentity/Account/SignedOut")
                        {
                            context.HttpContext.Response.Redirect("/");
                        }
                    }
                    ));

            

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.MapControllers();

            app.Run();
        }
    }
}