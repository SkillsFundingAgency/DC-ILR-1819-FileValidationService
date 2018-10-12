namespace ESFA.DC.ILR.FileValidationService.Service.Interface.Enum
{
    public enum Severity
    {
        Error,
        Warning,

        /// <summary>
        /// File is determined to be unreadable, and not able to validated.
        /// </summary>
        Fail
    }
}
