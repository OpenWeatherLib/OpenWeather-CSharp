using System;
using System.Linq;
using System.Reflection;

namespace GuepardoApps.OpenWeatherLib.Crosscutting.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static TAttribute GetSingleAttribute<TAttribute>(this PropertyInfo propertyInfo, bool inherit = true)
            where TAttribute : Attribute => (TAttribute)propertyInfo.GetCustomAttributes(typeof(TAttribute), inherit).FirstOrDefault();
    }
}
