using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring : ILooseEmploymentStatusMonitoring
    {
        public long? ESMCodeNullable => eSMCodeFieldSpecified ? eSMCodeField : default(long?);
    }
}
