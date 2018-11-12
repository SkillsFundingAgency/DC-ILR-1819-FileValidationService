using System.Collections.Generic;
using System.Xml.Schema;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IValidationErrorHandler
    {
        IEnumerable<IValidationError> ValidationErrors { get; }

        void XsdValidationErrorHandler(object sender, ValidationEventArgs e);

        void FileFailureErrorHandler(string ruleName);

        void AddRange(IEnumerable<IValidationError> validationErrors);

        IErrorMessageParameter BuildErrorMessageParameter(string propertyName, object value);
    }
}
