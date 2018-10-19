using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLLDDandHealthProblem : ILooseLLDDAndHealthProblem
    {
        public long? LLDDCatNullable => lLDDCatFieldSpecified ? lLDDCatField : default(long?);

        public long? PrimaryLLDDNullable => primaryLLDDFieldSpecified ? primaryLLDDField : default(long?);
    }
}
