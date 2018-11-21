using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class AppFinRecordMapper : AbstractModelMapper<Loose.MessageLearnerLearningDeliveryAppFinRecord, MessageLearnerLearningDeliveryAppFinRecord>
    {
        protected override MessageLearnerLearningDeliveryAppFinRecord MapModel(Loose.MessageLearnerLearningDeliveryAppFinRecord model)
        {
            return new MessageLearnerLearningDeliveryAppFinRecord()
            {
                AFinAmount = (int)model.AFinAmount,
                AFinCode = (int)model.AFinCode,
                AFinDate = model.AFinDate,
                AFinType = model.AFinType,
            };
        }
    }
}
