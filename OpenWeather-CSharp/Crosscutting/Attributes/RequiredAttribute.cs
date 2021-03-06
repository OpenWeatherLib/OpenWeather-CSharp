﻿using System;

namespace GuepardoApps.OpenWeatherLib.Crosscutting.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : Attribute
    {
        public readonly Type Type;

        public RequiredAttribute(Type type)
        {
            Type = type;
        }
    }
}
