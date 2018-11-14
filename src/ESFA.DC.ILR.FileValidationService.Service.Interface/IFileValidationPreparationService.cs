using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationPreparationService
    {
        Task Prepare(IFileValidationContext fileValidationContext, CancellationToken cancellationToken);
    }
}
