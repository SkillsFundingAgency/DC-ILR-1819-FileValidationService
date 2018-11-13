using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearningDelivery
    {
        string LearnAimRef { get; }

        string DelLocPostCode { get; }

        string ConRefNumber { get; }

        string EPAOrgID { get; }

        string OutGrade { get; }

        long? OutcomeNullable { get; }

        string SWSupAimId { get; }

        long? AimTypeNullable { get; }

        long? AimSeqNumberNullable { get; }

        long? FundModelNullable { get; }

        long? ProgTypeNullable { get; }

        long? FworkCodeNullable { get; }

        long? PwayCodeNullable { get; }

        long? StdCodeNullable { get; }

        long? CompStatusNullable { get; }
        
        DateTime? OrigLearnStartDateNullable { get; }

        DateTime? LearnStartDateNullable { get; }

        DateTime? LearnPlanEndDateNullable { get; }

        DateTime? LearnActEndDateNullable { get; }

        DateTime? AchDateNullable { get; }

        long? PartnerUKPRNNullable { get; }

        long? AddHoursNullable { get; }

        long? PriorLearnFundAdjNullable { get; }

        long? OtherFundAdjNullable { get; }

        long? EmpOutcomeNullable { get; }

        long? WithdrawReasonNullable { get; }

        IReadOnlyCollection<ILooseLearningDeliveryFAM> LearningDeliveryFAMs { get; }

        IReadOnlyCollection<ILooseAppFinRecord> AppFinRecords { get; }

        IReadOnlyCollection<ILooseProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitorings { get; }

        IReadOnlyCollection<ILooseLearningDeliveryHE> LearningDeliveryHEs { get; }

        IReadOnlyCollection<ILooseLearningDeliveryWorkPlacement> LearningDeliveryWorkPlacements { get; }
    }
}
