using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationOutputService
    {
        Task OutputAsync(IFileValidationContext fileValidationContext, Model.Message message, IEnumerable<IValidationError> validationErrors, CancellationToken cancellationToken);

        Task OutputFileValidationFailureAsync(IFileValidationContext fileValidationContext, IEnumerable<IValidationError> validationErrors, CancellationToken cancellationToken);
    }
}
