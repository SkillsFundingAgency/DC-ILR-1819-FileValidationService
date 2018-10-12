namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IXsdService
    {
        Model.Loose.Message Validate(string input);
    }
}
