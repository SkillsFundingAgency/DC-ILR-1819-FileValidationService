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

        public long? CompStatusNullable => compStatusFieldSpecified ? compStatusField : default(long?);

        public DateTime? LearnStartDateNullable => learnStartDateFieldSpecified ? learnStartDateField : default(DateTime?);

        public DateTime? LearnPlanEndDateNullable => learnPlanEndDateFieldSpecified ? learnPlanEndDateField : default(DateTime?);

        public IReadOnlyCollection<ILooseLearningDeliveryFAM> LearningDeliveryFAMs => learningDeliveryFAMField;

        public IReadOnlyCollection<ILooseAppFinRecord> AppFinRecords => appFinRecordField;

        public IReadOnlyCollection<ILooseProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitorings => providerSpecDeliveryMonitoringField;

        public IReadOnlyCollection<ILooseLearningDeliveryHE> LearningDeliveryHEs => learningDeliveryHEField;

        public IReadOnlyCollection<ILooseLearningDeliveryWorkPlacement> LearningDeliveryWorkPlacements =>learningDeliveryWorkPlacementField;
    }
}
