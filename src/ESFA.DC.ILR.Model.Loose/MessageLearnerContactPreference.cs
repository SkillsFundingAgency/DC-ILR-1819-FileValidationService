using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerContactPreference : ILooseContactPreference
    {
        public long? ContPrefCodeNullable => contPrefCodeFieldSpecified ? contPrefCodeField : default(long?);
    }
}
