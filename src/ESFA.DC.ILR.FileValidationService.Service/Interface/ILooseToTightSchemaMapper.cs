using ESFA.DC.ILR.Model;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface ILooseToTightSchemaMapper
    {
        Message Map(Model.Loose.Message looseMessage);
    }
}
