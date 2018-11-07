using System;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.FileValidationService.Stateless
{
    public class MessageHandler : IMessageHandler<JobContextMessage>
    {
        private readonly ILogger _logger;

        public MessageHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> HandleAsync(JobContextMessage message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
