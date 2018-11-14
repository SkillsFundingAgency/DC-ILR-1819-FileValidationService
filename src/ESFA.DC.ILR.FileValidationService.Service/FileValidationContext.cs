using ESFA.DC.ILR.FileValidationService.Service.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationContext : IFileValidationContext
    {
        public string FileReference { get; set; }

        public string Container { get; set; }

        public string OriginalFileReference { get; set; }
        
        public string ValidationErrorsKey { get; set; }
    }
}
