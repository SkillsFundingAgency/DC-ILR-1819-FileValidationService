using System.Threading;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface ILooseMessageProvider
    {
        Task<Model.Loose.Message> ProvideAsync(IFileValidationContext fileValidationContext, CancellationToken cancellationToken);
    }
}
