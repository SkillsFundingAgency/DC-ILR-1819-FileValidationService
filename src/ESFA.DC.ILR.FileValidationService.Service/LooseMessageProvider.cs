using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class LooseMessageProvider : ILooseMessageProvider
    {
        private readonly IFileService _fileService;
        private readonly IXmlSerializationService _xmlSerializationService;
        private readonly IXsdValidationService _xsdValidationService;

        public LooseMessageProvider(IFileService fileService, IXmlSerializationService xmlSerializationService, IXsdValidationService xsdValidationService)
        {
            _fileService = fileService;
            _xmlSerializationService = xmlSerializationService;
            _xsdValidationService = xsdValidationService;
        }

        public async Task<Message> ProvideAsync(IFileValidationContext fileValidationContext, CancellationToken cancellationToken)
        {
            using (var stream = await _fileService.OpenReadStreamAsync(fileValidationContext.FileReference, fileValidationContext.Container, cancellationToken))
            {
                _xsdValidationService.Validate(stream);

                stream.Position = 0;

                return _xmlSerializationService.Deserialize<Message>(stream);
            }
        }
    }
}
