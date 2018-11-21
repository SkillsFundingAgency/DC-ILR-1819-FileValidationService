using System.Linq;
using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Interface;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearnerDestinationAndProgressionMapper : AbstractModelMapper<Loose.MessageLearnerDestinationandProgression, MessageLearnerDestinationandProgression>
    {
        private readonly IModelMapper<Loose.MessageLearnerDestinationandProgressionDPOutcome, MessageLearnerDestinationandProgressionDPOutcome> _dpOutcomeMapper;

        public LearnerDestinationAndProgressionMapper(IModelMapper<Loose.MessageLearnerDestinationandProgressionDPOutcome, MessageLearnerDestinationandProgressionDPOutcome> dpOutcomeMapper)
        {
            _dpOutcomeMapper = dpOutcomeMapper;
        }

        protected override MessageLearnerDestinationandProgression MapModel(Loose.MessageLearnerDestinationandProgression model)
        {
            return new MessageLearnerDestinationandProgression()
            {
                DPOutcome = model.DPOutcome?.Select(o => _dpOutcomeMapper.Map(o)).ToArray(),
                LearnRefNumber = model.LearnRefNumber,
                ULN = model.ULN,
            };
        }
    }
}
