using System.Collections.Generic;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationRuleExecutionService
    {
        IEnumerable<IValidationError> Execute(Model.Loose.Message message);
    }
}
