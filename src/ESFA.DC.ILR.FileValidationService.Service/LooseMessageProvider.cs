using System.Threading.Tasks;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class LooseMessageProvider : ILooseMessageProvider
    {
        public Task<Message> Provide(IFileValidationContext fileValidationContext)
        {
            // Load String from File

            // XSD Validation

            // Throw Exception if Fail

            // Deserialize
            return Task.FromResult(new Message());
        }
    }
}
