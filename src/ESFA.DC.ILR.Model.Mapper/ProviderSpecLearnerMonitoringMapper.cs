using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class ProviderSpecLearnerMonitoringMapper : AbstractModelMapper<Loose.MessageLearnerProviderSpecLearnerMonitoring, MessageLearnerProviderSpecLearnerMonitoring>
    {
        protected override MessageLearnerProviderSpecLearnerMonitoring MapModel(Loose.MessageLearnerProviderSpecLearnerMonitoring model)
        {
            return new MessageLearnerProviderSpecLearnerMonitoring()
            {
                ProvSpecLearnMon = model.ProvSpecLearnMon.Sanitize(),
                ProvSpecLearnMonOccur = model.ProvSpecLearnMonOccur.Sanitize(),
            };
        }
    }
}
