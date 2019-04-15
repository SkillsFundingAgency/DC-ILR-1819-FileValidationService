using System.Linq;
using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;
using ESFA.DC.ILR.Model.Mapper.Interface;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearnerEmploymentStatusMapper : AbstractModelMapper<Loose.MessageLearnerLearnerEmploymentStatus, MessageLearnerLearnerEmploymentStatus>
    {
        private readonly IModelMapper<Loose.MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring, MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring> _employmentStatusMonitoringMapper;

        public LearnerEmploymentStatusMapper(IModelMapper<Loose.MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring, MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring> employmentStatusMonitoringMapper)
        {
            _employmentStatusMonitoringMapper = employmentStatusMonitoringMapper;
        }

        protected override MessageLearnerLearnerEmploymentStatus MapModel(Loose.MessageLearnerLearnerEmploymentStatus model)
        {
            return new MessageLearnerLearnerEmploymentStatus()
            {
                AgreeId = model.AgreeId.Sanitize(),
                DateEmpStatApp = model.DateEmpStatApp,
                EmpId = (int)model.EmpId,
                EmpIdSpecified = model.EmpIdSpecified,
                EmploymentStatusMonitoring = model.EmploymentStatusMonitoring?.Select(m => _employmentStatusMonitoringMapper.Map(m)).ToArray(),
                EmpStat = (int)model.EmpStat,
            };
        }
    }
}
