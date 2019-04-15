using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;

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
                Release = model.Release.Sanitize(),
                SerialNo = model.SerialNo.Sanitize(),
                SoftwarePackage = model.SoftwarePackage.Sanitize(),
                SoftwareSupplier = model.SoftwareSupplier.Sanitize(),
                SourceFileName = model.SourceFileName.Sanitize()
            };
        }
    }
}
