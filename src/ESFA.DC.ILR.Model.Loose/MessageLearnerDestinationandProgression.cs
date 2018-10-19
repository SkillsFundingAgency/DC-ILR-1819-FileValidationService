using System.Collections.Generic;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerDestinationandProgression : ILooseLearnerDestinationAndProgression
    {
        public long? ULNNullable => uLNFieldSpecified ? uLNField : default(long?);

        public IReadOnlyCollection<ILooseDPOutcome> DPOutcomes => dPOutcomeField;
    }
}
