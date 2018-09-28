using System;
using System.Linq;
using System.Reflection;

namespace Crosscutting.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static TAttribute GetSingleAttribute<TAttribute>(this PropertyInfo propertyInfo, bool inherit = true) where TAttribute : Attribute
        {
            var foundAttributes = propertyInfo.GetCustomAttributes(typeof(TAttribute), inherit);
            if (foundAttributes.Any())
            {
                return (TAttribute)foundAttributes[0];
            }

            return null;
        }
    }
}
