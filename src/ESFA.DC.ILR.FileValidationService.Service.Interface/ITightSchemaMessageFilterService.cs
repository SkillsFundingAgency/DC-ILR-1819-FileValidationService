using System.Collections.Generic;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface ITightSchemaValidMessageFilterService
    {
        Model.Loose.Message ApplyFilter(Model.Loose.Message message, IEnumerable<IValidationError> validationErrors);
    }
}
