using System.Collections.Generic;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationRuleExecutionService : IFileValidationRuleExecutionService
    {
        public IEnumerable<IValidationError> Execute(Message message)
        {
            return new List<IValidationError>();
        }
    }
}
