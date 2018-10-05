using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationRuleExecutionService
    {
        IEnumerable<IValidationError> Execute(Model.Loose.Message message);
    }
}
