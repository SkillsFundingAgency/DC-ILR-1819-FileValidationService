using System;
using System.Collections.Generic;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearningDelivery : ILooseLearningDelivery
    {
        public long? AimTypeNullable => aimTypeFieldSpecified ? aimTypeField : default(long?);

        public long? AimSeqNumberNullable => aimSeqNumberFieldSpecified ? aimSeqNumberField : default(long?);

        public long? FundModelNullable => fundModelFieldSpecified ? fundModelField : default(long?);

        public long? ProgTypeNullable => progTypeFieldSpecified ? progTypeField : default(long?);

        public long? FworkCodeNullable => fworkCodeFieldSpecified ? fworkCodeField : default(long?);

        public long? PwayCodeNullable => pwayCodeFieldSpecified ? pwayCodeField : default(long?);

        public long? StdCodeNullable => stdCodeFieldSpecified ? stdCodeField : default(long?);

        public long? CompStatusNullable => compStatusFieldSpecified ? compStatusField : default(long?);

        public DateTime? OrigLearnStartDateNullable => OrigLearnStartDateSpecified ? OrigLearnStartDate : default(DateTime?);

        public DateTime? LearnStartDateNullable => learnStartDateFieldSpecified ? learnStartDateField : default(DateTime?);

        public DateTime? LearnPlanEndDateNullable => learnPlanEndDateFieldSpecified ? learnPlanEndDateField : default(DateTime?);

        public DateTime? LearnActEndDateNullable => LearnActEndDateSpecified ? LearnActEndDate : default(DateTime?);

        public DateTime? AchDateNullable => AchDateSpecified ? AchDate : default(DateTime?);

        public long? PartnerUKPRNNullable => partnerUKPRNFieldSpecified ? partnerUKPRNField : default(long?);

        public long? OutcomeNullable => outcomeFieldSpecified ? outcomeField : default(long?);

        public long? AddHoursNullable => addHoursFieldSpecified ? addHoursField : default(long?);

        public long? PriorLearnFundAdjNullable => priorLearnFundAdjFieldSpecified ? priorLearnFundAdjField : default(long?);

        public long? OtherFundAdjNullable => otherFundAdjFieldSpecified ? otherFundAdjField : default(long?);

        public long? EmpOutcomeNullable => empOutcomeFieldSpecified ? empOutcomeField : default(long?);

        public long? WithdrawReasonNullable => withdrawReasonFieldSpecified ? withdrawReasonField : default(long?);

        public IReadOnlyCollection<ILooseLearningDeliveryFAM> LearningDeliveryFAMs => learningDeliveryFAMField;

        public IReadOnlyCollection<ILooseAppFinRecord> AppFinRecords => appFinRecordField;

        public IReadOnlyCollection<ILooseProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitorings => providerSpecDeliveryMonitoringField;

        public IReadOnlyCollection<ILooseLearningDeliveryHE> LearningDeliveryHEs => learningDeliveryHEField;

        public IReadOnlyCollection<ILooseLearningDeliveryWorkPlacement> LearningDeliveryWorkPlacements =>learningDeliveryWorkPlacementField;
    }
}
