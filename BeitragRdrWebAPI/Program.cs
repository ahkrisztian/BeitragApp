using BeitragRdrDataAccessLibrary.Data;
using BeitragRdrDataAccessLibrary.JsonDocFilter;
using BeitragRdrDataAccessLibrary.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Text.Json.Serialization;

namespace BeitragRdrWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy("OpenCorsPolicy", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
               );


            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });

            //builder.Services.AddHttpClient<IHttpDataAccess, HttpDataAccess>("base", client =>
            //{
            //    client.BaseAddress = new Uri(builder.Configuration["api_base_url"]);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //});

            //builder.Services.AddScoped<IHttpDataAccess, HttpDataAccess>();

            builder.Services.AddScoped<IBeitragRepo, BeitragRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers();


            builder.Services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Beitrag Creator",
                    Description = "Beiträge Anlegen, Lesen, Aktualisieren und Löschen für FB, Insta und Pinterest.",
                    Contact = new OpenApiContact()
                    {
                        Name = "Krisztian",
                        Url = new Uri("https://github.com/ahkrisztian")
                    }
                });



                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));

                opts.DocumentFilter<JsonPatchDocumentFilter>();
            });

            //builder.Services.AddAuthorization(opt =>
            //{
            //    opt.FallbackPolicy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .Build();
            //});

            builder.Services.AddApiVersioning(opts =>
            {
                opts.AssumeDefaultVersionWhenUnspecified = true;
                opts.DefaultApiVersion = new(1, 0);
                opts.ReportApiVersions = true;
            });

            builder.Services.AddVersionedApiExplorer(opts =>
            {
                opts.GroupNameFormat = "'v'VVV";
                opts.SubstituteApiVersionInUrl= true;
            });


            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(opts =>
                {
                    opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    opts.RoutePrefix = string.Empty;

                    opts.DefaultModelsExpandDepth(-1);
                });
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}