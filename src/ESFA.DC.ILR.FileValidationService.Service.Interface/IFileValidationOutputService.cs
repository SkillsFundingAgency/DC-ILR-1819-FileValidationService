using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationOutputService
    {
        Task Output(Model.Message message, IEnumerable<IValidationError> validationErrors);
    }
}
