using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearner
    {
        string LearnRefNumber { get; }

        string PrevLearnRefNumber { get; }

        string FamilyName { get; }

        string GivenNames { get; }

        string Sex { get; }

        string NINumber { get; }

        string MathGrade { get; }

        string EngGrade { get; }

        string PostcodePrior { get; }

        string Postcode { get; }

        string AddLine1 { get; }

        string AddLine2 { get; }

        string AddLine3 { get; }

        string AddLine4 { get; }

        string TelNo { get; }

        string Email { get; }

        string CampId { get; }

        long? ULNNullable { get; }

        long? EthnicityNullable { get; }

        long? LLDDHealthProbNullable { get; }

        long? PrevUKPRNNullable { get; }

        long? PMUKPRNNullable { get; }

        long? PriorAttainNullable { get; }

        long? AccomNullable { get; }

        long? ALSCostNullable { get; }

        long? PlanLearnHoursNullable { get; }

        long? PlanEEPHoursNullable { get; }

        long? OTJHoursNullable { get; }

        DateTime? DateOfBirthNullable { get; }

        IReadOnlyCollection<ILooseContactPreference> ContactPreferences { get; }

        IReadOnlyCollection<ILooseLearnerFAM> LearnerFAMs { get; }

        IReadOnlyCollection<ILooseProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings { get; }

        IReadOnlyCollection<ILooseLearnerEmploymentStatus> LearnerEmploymentStatuses { get; }

        IReadOnlyCollection<ILooseLearnerHE> LearnerHEs { get; }

        IReadOnlyCollection<ILooseLearningDelivery> LearningDeliveries { get; }

        IReadOnlyCollection<ILooseLLDDAndHealthProblem> LLDDAndHealthProblems { get; }
    }
}
