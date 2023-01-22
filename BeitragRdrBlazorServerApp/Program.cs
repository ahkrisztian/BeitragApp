using BeitragRdrBlazorServerApp.Data;
using BeitragRdrBlazorServerApp.Policies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BeitragRdrBlazorServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddSingleton<ClientPolicies>(new ClientPolicies());
            

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });

            builder.Services.AddHttpClient<IHttpDataAccess, HttpDataAccess>("base", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["api_base_url"]);
                client.DefaultRequestHeaders.Accept.Clear();
            });

            builder.Services.AddScoped<IHttpDataAccess, HttpDataAccess>();

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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}