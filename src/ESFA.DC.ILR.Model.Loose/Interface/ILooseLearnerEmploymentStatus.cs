using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearnerEmploymentStatus
    {
        string AgreeId { get; }

        long? EmpStatNullable { get; }

        long? EmpIdNullable { get; }

        DateTime? DateEmpStatAppNullable { get; }

        IReadOnlyCollection<ILooseEmploymentStatusMonitoring> EmploymentStatusMonitorings { get; }
    }
}
