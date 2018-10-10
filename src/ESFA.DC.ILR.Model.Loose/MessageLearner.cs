using System.Collections.Generic;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearner : ILooseLearner
    {
        public IReadOnlyCollection<ILooseContactPreference> ContactPreferences => contactPreferenceField;
    }
}
