using System;

namespace GuepardoApps.OpenWeatherLib.Services.Validation
{
    public interface IValidationService
    {
        bool Validate<T>(T validationObject, params Func<bool>[] additionalValidations);
    }
}
