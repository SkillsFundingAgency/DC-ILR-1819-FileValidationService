using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationOutputService
    {
        Task Output(IFileValidationContext fileValidationContext, Model.Message message, IEnumerable<IValidationError> validationErrors, CancellationToken cancellationToken);
    }
}
