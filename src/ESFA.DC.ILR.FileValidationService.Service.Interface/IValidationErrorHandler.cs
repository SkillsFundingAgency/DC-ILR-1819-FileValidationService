using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IValidationErrorHandler
    {
        IEnumerable<IValidationError> ValidationErrors { get; }

        void XsdValidationErrorHandler(object sender, ValidationEventArgs e);

        void XmlValidationErrorHandler(XmlException xmlException);

        void FileFailureErrorHandler(string ruleName);

        void AddRange(IEnumerable<IValidationError> validationErrors);

        IErrorMessageParameter BuildErrorMessageParameter(string propertyName, object value);
    }
}
