using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace GuepardoApps.OpenWeatherLib.Crosscutting.Helper
{
    public static class AssemblyHelper
    {
        public static Assembly[] GetAssemblies(string namespacePrefix = null)
        {
            return DependencyContext.Default.RuntimeLibraries
                .Where(x => namespacePrefix == null || x.Name.StartsWith(namespacePrefix))
                .Select(x => Assembly.Load(new AssemblyName(x.Name))).ToArray();
        }

        public static string GetAssemblyVersion(this Assembly assembly)
        {
            return assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}