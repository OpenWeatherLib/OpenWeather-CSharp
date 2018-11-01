using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using GuepardoApps.OpenWeatherLib.Crosscutting.Helper;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;

namespace GuepardoApps.OpenWeatherLib.Web
{
    /// <summary>
    /// Startup
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration">configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services">services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { options.AutomaticAuthentication = false; });
            services.AddMemoryCache();
            services.AddAutoMapper();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddControllersAsServices();

            services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc(Configuration["Swagger:Version"], new Info
                {
                    Title = Configuration["Swagger:Title"],
                    Version = Assembly.GetExecutingAssembly().GetAssemblyVersion(),
                    Description = Configuration["Swagger:Description"]
                });

                swaggerGenOptions.IncludeXmlComments(
                    $"{AppDomain.CurrentDomain.BaseDirectory}{Configuration["Swagger:DocumentationFile"]}");
                swaggerGenOptions.DescribeAllParametersInCamelCase();
                swaggerGenOptions.DescribeAllEnumsAsStrings();
            });
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">app</param>
        /// <param name="env">env</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == StatusCodes.Status404NotFound &&
                    !Path.HasExtension(context.Request.Path.Value) &&
                    !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = Configuration["Swagger:Title"];
                c.SwaggerEndpoint(
                    string.Format(Configuration["Swagger:Endpoint"], Configuration["BackendBasepath"],
                        Configuration["Swagger:Version"]),
                    string.Format(Configuration["Swagger:EndpointName"], Assembly.GetExecutingAssembly().GetAssemblyVersion()));
            });
        }
    }
}
