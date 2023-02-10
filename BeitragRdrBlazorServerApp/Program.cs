using BeitragRdrBlazorServerApp.Data;
using BeitragRdrBlazorServerApp.Policies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Rewrite;
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


            builder.Services.AddSingleton<ClientPolicies>(new ClientPolicies());

            //builder.Services.AddVersionedApiExplorer().AddMicrosoftIdentityConsentHandler();

            builder.Services.AddApiVersioning();


            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });

            builder.Services.AddHttpClient<IHttpDataAccess, HttpDataAccess>("base", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["api_base_url"]);
                client.DefaultRequestHeaders.Accept.Clear();
            });

            builder.Services.AddScoped<IHttpDataAccess, HttpDataAccess>();

            

            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

            builder.Services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim("jobTitle", "Admin");
                });
            });

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