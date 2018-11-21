using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface.Exception;
using ESFA.DC.ILR.FileValidationService.Stateless.Context;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.Logging.Interfaces;
using ExecutionContext = ESFA.DC.Logging.ExecutionContext;

namespace ESFA.DC.ILR.FileValidationService.Stateless
{
    public class MessageHandler : IMessageHandler<JobContextMessage>
    {
        private readonly ILifetimeScope _lifetimeScope;

        private const string ReportsTopicName = "Reports";

        public MessageHandler(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task<bool> HandleAsync(JobContextMessage message, CancellationToken cancellationToken)
        {
            var fileValidationContext = new FileValidationJobContextMessageContext(message);

            using (var childLifetimeScope = _lifetimeScope.BeginLifetimeScope())
            {
                var executionContext = (ExecutionContext) childLifetimeScope.Resolve<IExecutionContext>();
                executionContext.JobId = message.JobId.ToString();

                var fileValidationOrchestrationService = childLifetimeScope.Resolve<IFileValidationOrchestrationService>();

                try
                {
                    await fileValidationOrchestrationService.Validate(fileValidationContext, cancellationToken);
                }
                catch (FileValidationServiceFileFailureException fileFailureException)
                {
                    if (message.Topics.Any(t => t.SubscriptionName == ReportsTopicName))
                    {
                        message.TopicPointer = message.Topics.ToList().FindIndex(t => t.SubscriptionName == ReportsTopicName) - 1;
                    }
                }

                return true;
            }
        }
    }
}
