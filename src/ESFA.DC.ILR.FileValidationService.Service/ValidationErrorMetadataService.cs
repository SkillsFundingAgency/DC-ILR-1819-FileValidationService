using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FileValidationService.Service.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class ValidationErrorMetadataService : IValidationErrorMetadataService
    {
        public bool IsSchemaValid(IEnumerable<IValidationError> validationErrors)
        {
            return !validationErrors.Any(ve => ve.RuleName == ValidationErrorHandler.SchemaRuleName);
        }
    }
}
