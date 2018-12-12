using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FileValidationService.Service.Interface;

namespace ESFA.DC.ILR.FileValidationService.Console.Stubs
{
    public class FileValidationPreparationServiceStub : IFileValidationPreparationService
    {
        public Task Prepare(IFileValidationContext fileValidationContext, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
