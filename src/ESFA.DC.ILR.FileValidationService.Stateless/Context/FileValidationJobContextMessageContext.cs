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

        public string FileReference
        {
            get => _jobContextMessage.KeyValuePairs[ILRJobContextMessageKeys.Filename].ToString();
            set => _jobContextMessage.KeyValuePairs[ILRJobContextMessageKeys.Filename] = value;
        }

        public string OriginalFileReference
        {
            get => _jobContextMessage.KeyValuePairs[ILRJobContextMessageKeys.OriginalFilename].ToString();
            set => _jobContextMessage.KeyValuePairs[ILRJobContextMessageKeys.OriginalFilename] = value;
        }

        public string Container => _jobContextMessage.KeyValuePairs[ILRJobContextMessageKeys.Container].ToString();

        public string ValidationErrorsKey => _jobContextMessage.KeyValuePairs[ILRJobContextMessageKeys.ValidationErrors].ToString();


    }
}
