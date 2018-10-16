using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearnerDestinationAndProgression
    {
        string LearnRefNumber { get; }

        long? ULNNullable { get; }

        IReadOnlyCollection<ILooseDPOutcome> DPOutcomes { get; }
    }
}
