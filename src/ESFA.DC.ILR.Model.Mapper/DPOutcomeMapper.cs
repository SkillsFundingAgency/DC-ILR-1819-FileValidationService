using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class DPOutcomeMapper : AbstractModelMapper<Loose.MessageLearnerDestinationandProgressionDPOutcome, MessageLearnerDestinationandProgressionDPOutcome>
    {
        protected override MessageLearnerDestinationandProgressionDPOutcome MapModel(Loose.MessageLearnerDestinationandProgressionDPOutcome model)
        {
            return new MessageLearnerDestinationandProgressionDPOutcome()
            {
                OutCode = (int)model.OutCode,
                OutCollDate = model.OutCollDate,
                OutEndDate = model.OutEndDate,
                OutEndDateSpecified = model.OutEndDateSpecified,
                OutStartDate = model.OutStartDate,
                OutType = model.OutType,
            };
        }
    }
}
