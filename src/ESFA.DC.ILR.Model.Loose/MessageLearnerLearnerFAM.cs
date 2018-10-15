using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearnerFAM : ILooseLearnerFAM
    {
        public long? LearnFAMCodeNullable => learnFAMCodeFieldSpecified ? learnFAMCodeField : default(long?);
    }
}
