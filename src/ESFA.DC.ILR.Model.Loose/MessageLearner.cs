using System.Collections.Generic;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearner : ILooseLearner
    {
        public long? ULNNullable => uLNFieldSpecified ? uLNField : default(long?);

        public long? EthnicityNullable => ethnicityFieldSpecified ? ethnicityField : default(long?);

        public long? LLDDHealthProbNullable => lLDDHealthProbFieldSpecified ? lLDDHealthProbField : default(long?);

        public IReadOnlyCollection<ILooseContactPreference> ContactPreferences => contactPreferenceField;

        public IReadOnlyCollection<ILooseLearnerFAM> LearnerFAMs => learnerFAMField;

        public IReadOnlyCollection<ILooseProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings => providerSpecLearnerMonitoringField;

        public IReadOnlyCollection<ILooseLearnerEmploymentStatus> LearnerEmploymentStatuses => learnerEmploymentStatusField;

        public IReadOnlyCollection<ILooseLearnerHE> LearnerHEs => learnerHEField;

        public IReadOnlyCollection<ILooseLearningDelivery> LearningDeliveries => learningDeliveryField;
    }
}
