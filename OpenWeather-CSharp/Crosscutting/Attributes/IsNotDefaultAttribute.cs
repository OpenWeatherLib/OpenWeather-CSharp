using System;

namespace Crosscutting.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsNotDefaultAttribute : Attribute
    {
        public readonly Type ValueType;

        public readonly object DefaultValue;

        public IsNotDefaultAttribute(Type valueType, object defaultValue)
        {
            ValueType = valueType;
            DefaultValue = defaultValue;
        }
    }
}
