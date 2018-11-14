using System;
using System.Collections.Generic;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearner : ILooseLearner
    {
        public long? ULNNullable => uLNFieldSpecified ? uLNField : default(long?);

        public long? EthnicityNullable => ethnicityFieldSpecified ? ethnicityField : default(long?);

        public long? LLDDHealthProbNullable => lLDDHealthProbFieldSpecified ? lLDDHealthProbField : default(long?);

        public long? PrevUKPRNNullable => prevUKPRNFieldSpecified ? prevUKPRNField : default(long?);

        public long? PMUKPRNNullable => pMUKPRNFieldSpecified ? pMUKPRNField : default(long?);

        public long? PriorAttainNullable => priorAttainFieldSpecified ? priorAttainField : default(long?);

        public long? AccomNullable => accomFieldSpecified ? accomField : default(long?);

        public long? ALSCostNullable => aLSCostFieldSpecified ? aLSCostField : default(long?);

        public long? PlanLearnHoursNullable => planLearnHoursFieldSpecified ? planLearnHoursField : default(long?);

        public long? PlanEEPHoursNullable => planEEPHoursFieldSpecified ? planEEPHoursField : default(long?);

        public long? OTJHoursNullable => oTJHoursFieldSpecified ? oTJHoursField : default(long?);

        public DateTime? DateOfBirthNullable => dateOfBirthFieldSpecified ? dateOfBirthField : default(DateTime?);

        public IReadOnlyCollection<ILooseContactPreference> ContactPreferences => contactPreferenceField;

        public IReadOnlyCollection<ILooseLearnerFAM> LearnerFAMs => learnerFAMField;

        public IReadOnlyCollection<ILooseProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings => providerSpecLearnerMonitoringField;

        public IReadOnlyCollection<ILooseLearnerEmploymentStatus> LearnerEmploymentStatuses => learnerEmploymentStatusField;

        public IReadOnlyCollection<ILooseLearnerHE> LearnerHEs => learnerHEField;

        public IReadOnlyCollection<ILooseLearningDelivery> LearningDeliveries => learningDeliveryField;

        public IReadOnlyCollection<ILooseLLDDAndHealthProblem> LLDDAndHealthProblems => lLDDandHealthProblemField;
    }
}
