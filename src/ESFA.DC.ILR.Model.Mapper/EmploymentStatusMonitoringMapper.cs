using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class EmploymentStatusMonitoringMapper : AbstractModelMapper<Loose.MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring, MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring>
    {
        protected override MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring MapModel(Loose.MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring model)
        {
            return new MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring()
            {
                ESMCode = (int)model.ESMCode,
                ESMType = model.ESMType.Sanitize(),
            };
        }
    }
}
