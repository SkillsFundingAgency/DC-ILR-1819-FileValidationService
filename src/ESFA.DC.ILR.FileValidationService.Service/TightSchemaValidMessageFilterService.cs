using System.Collections.Generic;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class TightSchemaValidMessageFilterService : ITightSchemaValidMessageFilterService
    {
        public Message ApplyFilter(Message message, IEnumerable<IValidationError> validationErrors)
        {
            return message;
        }
    }
}
