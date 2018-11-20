using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class SourceMapper : AbstractModelMapper<Loose.MessageHeaderSource, MessageHeaderSource>
    {
        protected override MessageHeaderSource MapModel(Loose.MessageHeaderSource model)
        {
            return new MessageHeaderSource()
            {
                ComponentSetVersion = model.ComponentSetVersion,
                DateTime = model.DateTime,
                ProtectiveMarking = (MessageHeaderSourceProtectiveMarking)model.ProtectiveMarking,
                ReferenceData = model.ReferenceData,
                Release = model.Release,
                SerialNo = model.SerialNo,
                SoftwarePackage = model.SoftwarePackage,
                SoftwareSupplier = model.SoftwareSupplier,
                UKPRN = model.UKPRN,
            };
        }
    }
}
