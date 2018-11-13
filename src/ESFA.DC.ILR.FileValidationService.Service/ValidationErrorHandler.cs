using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface.Enum;
using ESFA.DC.ILR.FileValidationService.Service.ValidationError.Model;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class ValidationErrorHandler : IValidationErrorHandler
    {
        public const string SchemaRuleName = "Schema";
        private const string LinePropertyName = "Line";
        private const string PositionPropertyName = "Property";
        private const string MessagePropertyName = "Message";

        private readonly ConcurrentBag<IValidationError> _validationErrors = new ConcurrentBag<IValidationError>();

        public IEnumerable<IValidationError> ValidationErrors => _validationErrors;

        public void XmlValidationErrorHandler(XmlException xmlException)
        {
            _validationErrors.Add(
                new ValidationError.Model.ValidationError(
                    SchemaRuleName,
                    severity:Severity.Fail,
                    errorMessageParameters: BuildXmlErrorMessageParameters(xmlException.LineNumber, xmlException.LinePosition, xmlException.Message)));
        }

        public void FileFailureErrorHandler(string ruleName)
        {
            _validationErrors.Add(new ValidationError.Model.ValidationError(ruleName, severity: Severity.Fail));
        }

        public void AddRange(IEnumerable<IValidationError> validationErrors)
        {
            foreach (var validationError in validationErrors)
            {
                _validationErrors.Add(validationError);
            }
        }

        public IErrorMessageParameter BuildErrorMessageParameter(string propertyName, object value)
        {
            return new ErrorMessageParameter(propertyName, value?.ToString());
        }

        public void XsdValidationErrorHandler(object sender, ValidationEventArgs e)
        {
            if (sender is IXmlLineInfo xmlLineInfo)
            {
                _validationErrors.Add(
                    new ValidationError.Model.ValidationError(
                        SchemaRuleName,
                        severity: Severity.Fail,
                        errorMessageParameters: BuildXmlErrorMessageParameters(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition, e.Message)));
            }
        }

        private IEnumerable<IErrorMessageParameter> BuildXmlErrorMessageParameters(int lineNumber, int linePosition, string message)
        {
            return new[]
            {
                BuildErrorMessageParameter(LinePropertyName, lineNumber),
                BuildErrorMessageParameter(PositionPropertyName, linePosition),
                BuildErrorMessageParameter(MessagePropertyName, message),
            };
        }
    }
}
