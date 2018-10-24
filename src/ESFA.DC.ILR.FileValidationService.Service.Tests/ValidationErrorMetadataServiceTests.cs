using System.Collections.Generic;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Service.Tests
{
    public class ValidationErrorMetadataServiceTests
    {
        [Fact]
        public void SchemaValid_True()
        {
            var validationErrors = new List<IValidationError>()
            {
                new ValidationError.Model.ValidationError("NotSchema", null),
                new ValidationError.Model.ValidationError("NotSchema", null)
            };

            NewService().IsSchemaValid(validationErrors).Should().BeTrue();
        }

        [Fact]
        public void SchemaValid_False()
        {
            var validationErrors = new List<IValidationError>()
            {
                new ValidationError.Model.ValidationError("NotSchema", null),
                new ValidationError.Model.ValidationError("Schema", null)
            };

            NewService().IsSchemaValid(validationErrors).Should().BeFalse();
        }

        private ValidationErrorMetadataService NewService()
        {
            return new ValidationErrorMetadataService();
        }
    }
}
