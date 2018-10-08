using System;
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

        public LooseMessageProvider(IFileService fileService, IXmlSerializationService xmlSerializationService)
        {
            _fileService = fileService;
            _xmlSerializationService = xmlSerializationService;
        }

        public async Task<Message> Provide(IFileValidationContext fileValidationContext)
        {
            // Load String from File
            var fileContent = await _fileService.ReadStringAsync(fileValidationContext.FileReference, fileValidationContext.Container);
            
            // XSD Validation

            // Throw Exception if Fail

            // Deserialize
            return _xmlSerializationService.Deserialize<Message>(fileContent);
        }
    }
}
