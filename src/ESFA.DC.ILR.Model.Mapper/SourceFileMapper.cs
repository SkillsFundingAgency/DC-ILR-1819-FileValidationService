using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class SourceFileMapper : AbstractModelMapper<Loose.MessageSourceFile, MessageSourceFile>
    {
        protected override MessageSourceFile MapModel(Loose.MessageSourceFile model)
        {
            return new MessageSourceFile()
            {
                DateTime = model.DateTime,
                DateTimeSpecified = model.DateTimeSpecified,
                FilePreparationDate = model.FilePreparationDate,
                Release = model.Release,
                SerialNo = model.SerialNo,
                SoftwarePackage = model.SoftwarePackage,
                SoftwareSupplier = model.SoftwareSupplier,
                SourceFileName = model.SourceFileName
            };
        }
    }
}
