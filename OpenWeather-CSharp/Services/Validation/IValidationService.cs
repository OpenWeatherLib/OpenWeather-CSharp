using System;

namespace Services.Validation
{
    public interface IValidationService
    {
        bool Validate<T>(T validationObject, params Func<bool>[] additionalValidations);
    }
}
