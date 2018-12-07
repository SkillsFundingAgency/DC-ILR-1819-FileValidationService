namespace ESFA.DC.ILR.FileValidationService.Service.Interface.Exception
{
    public class FileValidationServiceFileFailureException : System.Exception
    {
        public FileValidationServiceFileFailureException()
        {
        }

        public FileValidationServiceFileFailureException(string message)
            : base(message)
        {
        }

        public FileValidationServiceFileFailureException(string message, System.Exception innerException)
        : base(message, innerException)
        {
        }
    }
}
