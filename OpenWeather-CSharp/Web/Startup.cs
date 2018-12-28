using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Autofac;
using GuepardoApps.OpenWeatherLib.Crosscutting.Helper;
using GuepardoApps.OpenWeatherLib.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

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
        /// <param name="hostingEnvironment">hostingEnvironment</param>
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// HostingEnvironment
        /// </summary>
        public IHostingEnvironment HostingEnvironment { get; }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services">services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { options.AutomaticAuthentication = false; });
            services.AddMemoryCache();
            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddControllersAsServices();

            if (HostingEnvironment.IsDevelopment())
            {
                services.AddCors();
            }

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
        /// ConfigureContainer
        /// </summary>
        /// <param name="builder">ContainerBuilder</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(AssemblyHelper.GetAssemblies("GuepardoApps.OpenWeatherLib").ToArray());
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">app</param>
        /// <param name="env">env</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(builder => builder.UseMiddleware<GlobalExceptionHandlerMiddleware>());

            if (env.IsDevelopment())
            {
                app.UseCors(builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowCredentials();
                });

                app.UseDeveloperExceptionPage();
            }

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
