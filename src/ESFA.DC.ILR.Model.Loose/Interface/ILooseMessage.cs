using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseMessage
    {
        ILooseHeader HeaderEntity { get; }

        IReadOnlyCollection<ILooseSourceFile> SourceFilesCollection { get; }

        ILooseLearningProvider LearningProviderEntity { get; }

        IReadOnlyCollection<ILooseLearner> Learners { get; }

        IReadOnlyCollection<ILooseLearnerDestinationAndProgression> LearnerDestinationAndProgressions { get; }
    }
}
