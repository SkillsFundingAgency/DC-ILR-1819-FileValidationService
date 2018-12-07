using System.IO;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IXsdValidationService
    {
        void Validate(Stream stream);
    }
}
