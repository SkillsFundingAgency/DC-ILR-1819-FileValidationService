using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface.Enum;
using ESFA.DC.ILR.Model.Loose;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class TightSchemaValidMessageFilterService : ITightSchemaValidMessageFilterService
    {
        public Message ApplyFilter(Message message, IEnumerable<IValidationError> validationErrors)
        {
            var invalidLearners = new HashSet<string>(validationErrors.Where(e => e.Severity == Severity.Error).Select(e => e.LearnerReferenceNumber).Distinct());

            message.Learner = message.Learner.Where(l => !invalidLearners.Contains(l.LearnRefNumber)).ToArray();

            return message;
        }
    }
}
