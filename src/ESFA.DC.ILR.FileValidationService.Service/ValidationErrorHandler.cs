using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.FileValidationService.Service.ValidationError.Model;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class ValidationErrorHandler : IValidationErrorHandler
    {
        public IErrorMessageParameter BuildErrorMessageParameter(string propertyName, object value)
        {
            return new ErrorMessageParameter(propertyName, value?.ToString());
        }
    }
}
