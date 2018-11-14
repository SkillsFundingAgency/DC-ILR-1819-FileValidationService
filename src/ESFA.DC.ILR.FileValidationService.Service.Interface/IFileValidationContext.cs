namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationContext
    {
        string FileReference { get; set;  }

        string OriginalFileReference { get; set; }

        string Container { get; }
        
        string ValidationErrorsKey { get; }
    }
}
