using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearnerDestinationAndProgression
    {
        string LearnRefNumber { get; }

        IReadOnlyCollection<ILooseDPOutcome> DPOutcomes { get; }
    }
}
