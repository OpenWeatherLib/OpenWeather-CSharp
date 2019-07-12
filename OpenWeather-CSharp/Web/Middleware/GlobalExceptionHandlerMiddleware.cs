using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace GuepardoApps.OpenWeatherLib.Web.Middleware
{
    /// <summary>
    /// GlobalExceptionHandlerMiddleware
    /// </summary>
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger _logger;

        private readonly IConfiguration _configuration;

        private readonly IHostingEnvironment _environment;

        /// <summary>
        /// GlobalExceptionHandlerMiddleware
        /// </summary>
        /// <param name="next">Delegate</param>
        /// <param name="logger">Logger</param>
        /// <param name="configuration">Configuration</param>
        /// <param name="environment">Environment</param>
        public GlobalExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger logger,
            IConfiguration configuration,
            IHostingEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
            _environment = environment;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <returns>Task</returns>
        public async Task Invoke(HttpContext httpContext)
        {
            var exception = httpContext.Features.Get<IExceptionHandlerFeature>();
            if (exception?.Error != null)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                if (_environment.IsDevelopment() && !httpContext.Response.Headers.ContainsKey(CorsConstants.AccessControlAllowOrigin))
                {
                    httpContext.Response.Headers.Add(CorsConstants.AccessControlAllowOrigin, _configuration["ClientBaseUrl"]);
                }

                var method = httpContext.Request.Method;
                _logger.Fatal(exception.Error, "Unhandled exception processing {method}", method);

                await httpContext.Response.WriteAsync("An unhandled exception occured.").ConfigureAwait(false);
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}
