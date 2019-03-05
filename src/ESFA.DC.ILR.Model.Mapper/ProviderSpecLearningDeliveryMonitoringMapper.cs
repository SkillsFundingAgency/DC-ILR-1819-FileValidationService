using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class ProviderSpecLearningDeliveryMonitoringMapper : AbstractModelMapper<Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring, MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring>
    {
        protected override MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring MapModel(Loose.MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring model)
        {
            return new MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring()
            {
                ProvSpecDelMon = model.ProvSpecDelMon,
                ProvSpecDelMonOccur = model.ProvSpecDelMonOccur,
            };
        }
    }
}
