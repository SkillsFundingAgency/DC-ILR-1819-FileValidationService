using System.Collections.Generic;
using ESFA.DC.ILR.IO.Model.Validation;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationIOModelBuilder
    {
        IEnumerable<ValidationError> BuildValidationErrors(IEnumerable<IValidationError> validationErrors);
    }
}
