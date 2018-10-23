using System.IO;
using System.Xml;
using System.Xml.Schema;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose.Schema.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class XsdValidationService : IXsdValidationService
    {
        private readonly IXmlSchemaProvider _xmlSchemaProvider;
        private readonly IValidationErrorHandler _validationErrorHandler;
        private readonly IValidationErrorMetadataService _validationErrorMetadataService;

        public XsdValidationService(IXmlSchemaProvider xmlSchemaProvider, IValidationErrorHandler validationErrorHandler, IValidationErrorMetadataService validationErrorMetadataService)
        {
            _xmlSchemaProvider = xmlSchemaProvider;
            _validationErrorHandler = validationErrorHandler;
            _validationErrorMetadataService = validationErrorMetadataService;
        }

        public void Validate(Stream stream)
        {
            var xmlSchemaSet = BuildXmlSchemaSet();
            var xmlReaderSettings = BuildXmlReaderSettings(xmlSchemaSet);

            using (var xmlReader = XmlReader.Create(stream, xmlReaderSettings))
            {
                while (xmlReader.Read())
                {
                }
            }

            AssertValidity();
        }

        public void AssertValidity()
        {
            if (!_validationErrorMetadataService.IsSchemaValid(_validationErrorHandler.ValidationErrors))
            {
                throw new XmlSchemaException("Supplied XML does not conform to the XSD, see Validation Errors for Detailed Results.");
            }
        }

        public XmlSchemaSet BuildXmlSchemaSet()
        {
            var xmlSchemaSet = new XmlSchemaSet()
            {
                CompilationSettings = new XmlSchemaCompilationSettings()
            };

            var xmlSchema = _xmlSchemaProvider.Provide();

            xmlSchemaSet.Add(xmlSchema);
            xmlSchemaSet.Compile();

            return xmlSchemaSet;
        }

        public XmlReaderSettings BuildXmlReaderSettings(XmlSchemaSet xmlSchemaSet)
        {
            var settings = new XmlReaderSettings()
            {
                CloseInput = false,
                ValidationType = ValidationType.Schema,
                Schemas = xmlSchemaSet,
                ValidationFlags = XmlSchemaValidationFlags.ProcessIdentityConstraints
            };

            settings.ValidationEventHandler += _validationErrorHandler.XsdValidationErrorHandler;

            return settings;
        }
    }
}
