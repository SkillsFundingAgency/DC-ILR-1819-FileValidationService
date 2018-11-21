using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearnerFAMMapper : AbstractModelMapper<Loose.MessageLearnerLearnerFAM, MessageLearnerLearnerFAM>
    {
        protected override MessageLearnerLearnerFAM MapModel(Loose.MessageLearnerLearnerFAM model)
        {
            return new MessageLearnerLearnerFAM()
            {
                LearnFAMCode = (int)model.LearnFAMCode,
                LearnFAMType = model.LearnFAMType,
            };
        }
    }
}
