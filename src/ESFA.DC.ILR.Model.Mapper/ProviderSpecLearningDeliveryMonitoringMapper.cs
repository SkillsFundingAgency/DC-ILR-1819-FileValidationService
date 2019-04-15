using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class ProviderSpecLearningDeliveryMonitoringMapper : AbstractModelMapper<Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring, MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring>
    {
        protected override MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring MapModel(Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring model)
        {
            return new MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring()
            {
                ProvSpecDelMon = model.ProvSpecDelMon.Sanitize(),
                ProvSpecDelMonOccur = model.ProvSpecDelMonOccur.Sanitize(),
            };
        }
    }
}
