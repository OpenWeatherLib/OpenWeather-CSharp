using System;
using System.Linq;
using Crosscutting.Attributes;
using Crosscutting.Extensions;

namespace Services.Validation
{
    public class ValidationService : IValidationService
    {
        public bool Validate<T>(T validationObject, params Func<bool>[] additionalValidations)
        {
            var valid = true;

            var defaultValidations = new Func<bool>[]
            {
                () => RequiredPropertiesAreProvided(validationObject),
                () => IsNotDefaultPropertiesAreNotDefault(validationObject)
            };

            var totalValidations = defaultValidations.Union(additionalValidations ?? new Func<bool>[0]).ToList();

            return valid;
        }

        private bool RequiredPropertiesAreProvided<T>(T validationObject)
        {
            var requiredProperties = validationObject.GetType().GetProperties()
                .Where(x => x.GetSingleAttribute<RequiredAttribute>() != null)
                .ToList();

            foreach (var requiredProperty in requiredProperties)
            {
                if (requiredProperty.GetValue(validationObject).IsEmpty())
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsNotDefaultPropertiesAreNotDefault<T>(T validationObject)
        {
            var isNotDefaultProperties = validationObject.GetType().GetProperties()
                .Where(x => x.GetSingleAttribute<IsNotDefaultAttribute>() != null)
                .Select(x => new
                {
                    property = x,
                    attribute = x.GetSingleAttribute<IsNotDefaultAttribute>()
                })
                .ToList();

            foreach (var isNotDefaultProperty in isNotDefaultProperties)
            {
                var valueType = isNotDefaultProperty.attribute.ValueType;

                var defaultValue = Convert.ChangeType(isNotDefaultProperty.attribute.DefaultValue, valueType);
                var propertyValue = Convert.ChangeType(isNotDefaultProperty.property.GetValue(validationObject), valueType);

                if (defaultValue == propertyValue)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
