using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESFA.DC.ILR.FileValidationService.Service.IO.Model;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationIOModelBuilder
    {
        IEnumerable<IO.Model.ValidationError> BuildValidationErrors(IEnumerable<IValidationError> validationErrors);
    }
}
