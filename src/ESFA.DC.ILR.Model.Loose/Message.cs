using System.Collections.Generic;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class Message : ILooseMessage
    {
        public ILooseHeader HeaderEntity => headerField;

        public IReadOnlyCollection<ILooseSourceFile> SourceFilesCollection => sourceFilesField;

        public ILooseLearningProvider LearningProviderEntity => learningProviderField;

        public IReadOnlyCollection<ILooseLearner> Learners => learnerField;

        public IReadOnlyCollection<ILooseLearnerDestinationAndProgression> LearnerDestinationAndProgressions => learnerDestinationandProgressionField;
    }
}
