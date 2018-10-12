using System.Collections.Generic;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.Model.Loose
{
    public partial class MessageLearnerLearnerEmploymentStatus : ILooseLearnerEmploymentStatus
    {
        public IReadOnlyCollection<ILooseEmploymentStatusMonitoring> EmploymentStatusMonitorings => employmentStatusMonitoringField;
    }
}
