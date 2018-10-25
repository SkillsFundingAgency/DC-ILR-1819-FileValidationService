namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationContext
    {
        string FileReference { get; }

        string OutputFileReference { get; }

        string Container { get; }
        
        string ValidationErrorsKey { get; }
    }
}
