using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class SourceMapper : AbstractModelMapper<Loose.MessageHeaderSource, MessageHeaderSource>
    {
        protected override MessageHeaderSource MapModel(Loose.MessageHeaderSource model)
        {
            return new MessageHeaderSource()
            {
                ComponentSetVersion = model.ComponentSetVersion.Sanitize(),
                DateTime = model.DateTime,
                ProtectiveMarking = (MessageHeaderSourceProtectiveMarking)model.ProtectiveMarking,
                ReferenceData = model.ReferenceData.Sanitize(),
                Release = model.Release.Sanitize(),
                SerialNo = model.SerialNo.Sanitize(),
                SoftwarePackage = model.SoftwarePackage.Sanitize(),
                SoftwareSupplier = model.SoftwareSupplier.Sanitize(),
                UKPRN = model.UKPRN,
            };
        }
    }
}
