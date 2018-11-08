using System.Collections.Generic;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IValidationErrorMetadataService
    {
        bool IsSchemaValid(IEnumerable<IValidationError> validationErrors);
    }
}
