using ESFA.DC.ILR.Constants;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.JobContextManager.Model;

namespace ESFA.DC.ILR.FileValidationService.Stateless.Context
{
    public class FileValidationJobContextMessageContext : IFileValidationContext
    {
        private readonly JobContextMessage _jobContextMessage;

        public FileValidationJobContextMessageContext(JobContextMessage jobContextMessage)
        {
            _jobContextMessage = jobContextMessage;
        }

        public string FileReference => _jobContextMessage.KeyValuePairs[ILRJobContextMessageKeys.Filename].ToString();

        public string OutputFileReference => "Tight_" + _jobContextMessage.KeyValuePairs[ILRJobContextMessageKeys.Filename];

        public string Container => _jobContextMessage.KeyValuePairs[ILRJobContextMessageKeys.Container].ToString();

        public string ValidationErrorsKey => _jobContextMessage.KeyValuePairs[ILRJobContextMessageKeys.ValidationErrors].ToString();
    }
}
