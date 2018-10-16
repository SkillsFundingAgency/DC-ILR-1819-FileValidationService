using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearnerHELearnerHEFinancialSupport : ILooseLearnerHEFinancialSupport
    {
        public long? FINTYPENullable => fINTYPEFieldSpecified ? fINTYPEField : default(long?);

        public long? FINAMOUNTNullable => fINAMOUNTFieldSpecified ? fINAMOUNTField : default(long?);
    }
}
