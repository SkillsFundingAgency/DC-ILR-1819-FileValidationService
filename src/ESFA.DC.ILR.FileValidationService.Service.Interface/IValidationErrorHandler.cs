using System.Collections.Generic;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IValidationErrorHandler
    {
        IErrorMessageParameter BuildErrorMessageParameter(string propertyName, object value);
    }
}
