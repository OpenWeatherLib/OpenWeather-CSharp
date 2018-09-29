using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using Autofac;
using AutofacSerilogIntegration;
using AutoMapper;
using GuepardoApps.OpenWeatherLib.Crosscutting.Helper;
using Microsoft.AspNetCore.Http;

namespace GuepardoApps.OpenWeatherLib.Web
{
    /// <summary>
    /// WebModules
    /// </summary>
    public class WebModules : Module
    {
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="builder">builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLogger();
            builder = RegisterAutoMapper(builder);
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.Register(context => context.Resolve<IHttpContextAccessor>().HttpContext.User).As<IPrincipal>();
        }

        private ContainerBuilder RegisterAutoMapper(ContainerBuilder builder)
        {
            var assemblies = AssemblyHelper.GetAssemblies("GuepardoApps.OpenWeatherLib");

            builder.RegisterAssemblyTypes(assemblies)
                   .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                   .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                var profiles = c.Resolve<IEnumerable<Profile>>().ToList();
#if DEBUG
                var information = new StringBuilder();
                information.AppendLine("Registration for the following Automapper Profiles:");
                profiles.ForEach(p => information.AppendLine(p.GetType().FullName));

                Debug.Write(information);
#endif
                profiles.ForEach(cfg.AddProfile);
                cfg.ConstructServicesUsing(d => builder.Build());
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                                   .CreateMapper(c.Resolve))
                   .As<IMapper>()
                   .InstancePerLifetimeScope();

            return builder;
        }
    }
}
