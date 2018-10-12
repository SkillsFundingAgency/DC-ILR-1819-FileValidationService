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

        string SWSupAimId { get; }

        IReadOnlyCollection<ILooseLearningDeliveryFAM> LearningDeliveryFAMs { get; }

        IReadOnlyCollection<ILooseAppFinRecord> AppFinRecords { get; }

        IReadOnlyCollection<ILooseProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitorings { get; }
    }
}
