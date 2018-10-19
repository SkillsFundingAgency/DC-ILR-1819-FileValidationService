using System;
using System.Collections.Generic;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearnerEmploymentStatus : ILooseLearnerEmploymentStatus
    {
        public long? EmpStatNullable => empStatFieldSpecified ? empStatField : default(long?);

        public long? EmpIdNullable => empIdFieldSpecified ? empIdField : default(long?);

        public DateTime? DateEmpStatAppNullable => dateEmpStatAppFieldSpecified ? dateEmpStatAppField : default(DateTime?);

        public IReadOnlyCollection<ILooseEmploymentStatusMonitoring> EmploymentStatusMonitorings => employmentStatusMonitoringField;
    }
}
