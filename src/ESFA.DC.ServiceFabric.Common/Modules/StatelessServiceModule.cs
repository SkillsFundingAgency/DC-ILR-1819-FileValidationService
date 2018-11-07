using System;
using System.Collections.Generic;
using Autofac;
using ESFA.DC.Auditing.Interface;
using ESFA.DC.JobContext.Interface;
using ESFA.DC.JobContextManager;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.JobStatus.Interface;
using ESFA.DC.Logging;
using ESFA.DC.Logging.Config;
using ESFA.DC.Logging.Config.Interfaces;
using ESFA.DC.Logging.Enums;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Mapping.Interface;
using ESFA.DC.Queueing;
using ESFA.DC.Queueing.Interface;
using ESFA.DC.Queueing.Interface.Configuration;
using ESFA.DC.ServiceFabric.Common.Config.Interface;
using ESFA.DC.ServiceFabric.Common.Stubs;

namespace ESFA.DC.ServiceFabric.Common.Modules
{
    public class StatelessServiceModule : Module
    {
        private readonly IStatelessServiceConfiguration _statelessServiceConfiguration;

        private const string QueueConfiguration = "queueConfiguration";
        private const string TopicConfiguration = "topicConfiguration";

        public StatelessServiceModule(IStatelessServiceConfiguration statelessServiceConfiguration)
        {
            _statelessServiceConfiguration = statelessServiceConfiguration;
        }

        protected override void Load(ContainerBuilder containerBuilder)
        {
            var topicConfiguration = BuildTopicConfiguration(_statelessServiceConfiguration);
            var jobStatusQueueConfiguration = BuildJobStatusQueueConfiguration(_statelessServiceConfiguration);
            var auditingQueueConfiguration = BuildAuditQueueConfiguration(_statelessServiceConfiguration);

            containerBuilder.RegisterType<JobContextManager<JobContextMessage>>().As<IJobContextManager<JobContextMessage>>();
            containerBuilder.RegisterType<TopicSubscriptionSevice<JobContextDto>>().WithParameter(TopicConfiguration, topicConfiguration).As<ITopicSubscriptionService<JobContextDto>>();
            containerBuilder.RegisterType<TopicPublishService<JobContextDto>>().WithParameter(TopicConfiguration, topicConfiguration).As<ITopicPublishService<JobContextDto>>();
            containerBuilder.RegisterType<DefaultJobContextMessageMapper<JobContextMessage>>().As<IMapper<JobContextMessage, JobContextMessage>>();
            containerBuilder.RegisterType<QueuePublishService<JobStatusDto>>().WithParameter(QueueConfiguration, jobStatusQueueConfiguration).As<IQueuePublishService<JobStatusDto>>();
            containerBuilder.RegisterType<QueuePublishService<AuditingDto>>().WithParameter(QueueConfiguration, auditingQueueConfiguration).As<IQueuePublishService<AuditingDto>>();

            containerBuilder.Register(c => new ApplicationLoggerSettings
            {
                ApplicationLoggerOutputSettingsCollection = new List<IApplicationLoggerOutputSettings>()
                {
                    new MsSqlServerApplicationLoggerOutputSettings()
                    {
                        MinimumLogLevel = LogLevel.Verbose,
                        ConnectionString = _statelessServiceConfiguration.LoggerConnectionString
                    },
                    new ConsoleApplicationLoggerOutputSettings()
                    {
                        MinimumLogLevel = LogLevel.Verbose
                    }
                }
            }).As<IApplicationLoggerSettings>().SingleInstance();

            containerBuilder.RegisterType<Logging.ExecutionContext>().As<IExecutionContext>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SerilogLoggerFactory>().As<ISerilogLoggerFactory>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SeriLogger>().As<ILogger>().InstancePerLifetimeScope();
        }

        private ITopicConfiguration BuildTopicConfiguration(IStatelessServiceConfiguration statelessServiceConfiguration)
        {
            return new TopicConfiguration(
                statelessServiceConfiguration.ServiceBusConnectionString,
                statelessServiceConfiguration.TopicName,
                statelessServiceConfiguration.SubscriptionName,
                int.Parse(statelessServiceConfiguration.TopicMaxConcurrentCalls),
                maximumCallbackTimeSpan: TimeSpan.FromMinutes(int.Parse(statelessServiceConfiguration.TopicMaxCallbackTimeSpanMinutes)));
        }

        private IQueueConfiguration BuildJobStatusQueueConfiguration(IStatelessServiceConfiguration statelessServiceConfiguration)
        {
            return new QueueConfiguration(
                statelessServiceConfiguration.ServiceBusConnectionString,
                statelessServiceConfiguration.JobStatusQueueName,
                int.Parse(statelessServiceConfiguration.JobStatusMaxConcurrentCalls));
        }

        private IQueueConfiguration BuildAuditQueueConfiguration(IStatelessServiceConfiguration statelessServiceConfiguration)
        {
            return new QueueConfiguration(
                statelessServiceConfiguration.ServiceBusConnectionString,
                statelessServiceConfiguration.AuditQueueName,
                int.Parse(statelessServiceConfiguration.AuditMaxConcurrentCalls));
        }
    }
}
