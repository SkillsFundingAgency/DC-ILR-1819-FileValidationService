using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearnerEmploymentStatus
    {
        string AgreeId { get; }

        IReadOnlyCollection<ILooseEmploymentStatusMonitoring> EmploymentStatusMonitorings { get; }
    }
}
