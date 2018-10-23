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

        public IErrorMessageParameter BuildErrorMessageParameter(string propertyName, object value)
        {
            return new ErrorMessageParameter(propertyName, value?.ToString());
        }

        public bool SchemaValid()
        {
            return _validationErrors.Any(ve => ve.RuleName == SchemaRuleName);
        }

        public void XsdValidationErrorHandler(object sender, ValidationEventArgs e)
        {
            var xmlLineInfo = sender as IXmlLineInfo;

            _validationErrors.Add(new ValidationError.Model.ValidationError(SchemaRuleName, null, null, Severity.Error,
                new []
                {
                    BuildErrorMessageParameter(LinePropertyName, xmlLineInfo.LineNumber),
                    BuildErrorMessageParameter(PositionPropertyName, xmlLineInfo.LinePosition),
                    BuildErrorMessageParameter(MessagePropertyName, e.Message),
                }));
        }

        
    }
}
