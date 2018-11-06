using System;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;

namespace ESFA.DC.ILR.FileValidationService.Stateless
{
    public class MessageHandler : IMessageHandler<JobContextMessage>
    {
        public Task<bool> HandleAsync(JobContextMessage message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
