using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationOrchestrationService
    {
        Task Validate(IFileValidationContext fileValidationContext, CancellationToken cancellationToken);
    }
}
