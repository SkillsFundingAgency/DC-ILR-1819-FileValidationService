using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose.Schema.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Service.Tests
{
    public class XsdValidationServiceTests
    {
        [Fact]
        public void AssertValidity_Valid()
        {
            var validationErrorCollection = new Mock<IEnumerable<IValidationError>>().Object;
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            validationErrorHandlerMock.SetupGet(h => h.ValidationErrors).Returns(validationErrorCollection);

            var validationErrorMetadataServiceMock = new Mock<IValidationErrorMetadataService>();

            validationErrorMetadataServiceMock.Setup(ms => ms.IsSchemaValid(validationErrorCollection)).Returns(true);

            Action action = () => NewService(
                validationErrorHandler: validationErrorHandlerMock.Object,
                validationErrorMetadataService: validationErrorMetadataServiceMock.Object)
                .AssertValidity();

            action.Should().NotThrow();
        }

        [Fact]
        public void AssertValidity_Invalid()
        {
            var validationErrorCollection = new Mock<IEnumerable<IValidationError>>().Object;
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            validationErrorHandlerMock.SetupGet(h => h.ValidationErrors).Returns(validationErrorCollection);

            var validationErrorMetadataServiceMock = new Mock<IValidationErrorMetadataService>();

            validationErrorMetadataServiceMock.Setup(ms => ms.IsSchemaValid(validationErrorCollection)).Returns(false);

            Action action = () => NewService(
                    validationErrorHandler: validationErrorHandlerMock.Object,
                    validationErrorMetadataService: validationErrorMetadataServiceMock.Object)
                .AssertValidity();

            action.Should().Throw<XmlSchemaException>().WithMessage("Supplied XML does not conform to the XSD, see Validation Errors for Detailed Results.");
        }

        [Fact]
        public void BuildXmlSchemaSet()
        {
            var xmlSchema = new XmlSchema();

            var xmlSchemaProviderMock = new Mock<IIlrLooseXmlSchemaProvider>();
            xmlSchemaProviderMock.Setup(p => p.Provide()).Returns(xmlSchema);

            var xmlSchemaSet = NewService(xmlSchemaProviderMock.Object).BuildXmlSchemaSet();

            xmlSchemaSet.CompilationSettings.Should().NotBeNull();
            xmlSchemaSet.Contains(xmlSchema).Should().BeTrue();
            xmlSchemaSet.IsCompiled.Should().BeTrue();
        }

        [Fact]
        public void BuildXmlReaderSettings()
        {
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            var xmlSchemaSet = new XmlSchemaSet();


            var xmlReaderSettings = NewService(validationErrorHandler: validationErrorHandlerMock.Object).BuildXmlReaderSettings(xmlSchemaSet);

            xmlReaderSettings.CloseInput.Should().BeFalse();
            xmlReaderSettings.ValidationType.Should().Be(ValidationType.Schema);
            xmlReaderSettings.Schemas.Should().Be(xmlSchemaSet);
            xmlReaderSettings.ValidationFlags.Should().Be(XmlSchemaValidationFlags.ProcessIdentityConstraints);
        }

        private XsdValidationService NewService(IIlrLooseXmlSchemaProvider xmlSchemaProvider = null, IValidationErrorHandler validationErrorHandler = null, IValidationErrorMetadataService validationErrorMetadataService = null)
        {
            return new XsdValidationService(xmlSchemaProvider, validationErrorHandler, validationErrorMetadataService);
        }
    }
}
