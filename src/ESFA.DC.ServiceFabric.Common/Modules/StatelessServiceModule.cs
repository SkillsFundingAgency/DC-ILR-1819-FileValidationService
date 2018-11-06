using Autofac;
using ESFA.DC.Auditing.Interface;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.JobStatus.Interface;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Mapping.Interface;
using ESFA.DC.Queueing;
using ESFA.DC.Queueing.Interface;
using ESFA.DC.Queueing.Interface.Configuration;
using ESFA.DC.ServiceFabric.Common.Stubs;

namespace ESFA.DC.ServiceFabric.Common.Modules
{
    public class StatelessServiceModule : Module
    {
        private readonly ITopicConfiguration _topicConfiguration;
        private readonly IQueueConfiguration _auditingQueueConfiguration;
        private readonly IQueueConfiguration _jobStatusQueueConfiguration;

        private const string QueueConfiguration = "queueConfiguration";
        private const string TopicConfiguration = "topicConfiguration";

        public StatelessServiceModule(ITopicConfiguration topicConfiguration, IQueueConfiguration auditingQueueConfiguration, IQueueConfiguration jobStatusQueueConfiguration)
        {
            _topicConfiguration = topicConfiguration;
            _auditingQueueConfiguration = auditingQueueConfiguration;
            _jobStatusQueueConfiguration = jobStatusQueueConfiguration;
        }

        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<JobContextManager<JobContextMessage>>().As<IJobContextManager<JobContextMessage>>();
            containerBuilder.RegisterType<TopicSubscriptionSevice<JobContextDto>>().WithParameter(TopicConfiguration, _topicConfiguration).As<ITopicSubscriptionService<JobContextDto>>();
            containerBuilder.RegisterType<TopicPublishService<JobContextDto>>().WithParameter(TopicConfiguration, _topicConfiguration).As<ITopicPublishService<JobContextDto>>();
            containerBuilder.RegisterType<DefaultJobContextMessageMapper<JobContextMessage>>().As<IMapper<JobContextMessage, JobContextMessage>>();
            containerBuilder.RegisterType<QueuePublishService<JobStatusDto>>().WithParameter(QueueConfiguration, _jobStatusQueueConfiguration).As<IQueuePublishService<JobStatusDto>>();
            containerBuilder.RegisterType<QueuePublishService<AuditingDto>>().WithParameter(QueueConfiguration, _auditingQueueConfiguration).As<IQueuePublishService<AuditingDto>>();
            
            containerBuilder.RegisterType<LoggerStub>().As<ILogger>();
        }
    }
}
