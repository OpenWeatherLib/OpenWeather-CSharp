using Autofac;

namespace Services
{
    public class AdapterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(t => t.Name.EndsWith("Adapter"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(t => t.Name.EndsWith("Converter"))
                .AsImplementedInterfaces();
        }
    }
}
