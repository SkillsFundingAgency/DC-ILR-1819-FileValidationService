using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationOutputService : IFileValidationOutputService
    {
        private readonly IXmlSerializationService _xmlSerializationService;
        private readonly IFileService _fileService;

        public FileValidationOutputService(IXmlSerializationService xmlSerializationService, IFileService fileService)
        {
            _xmlSerializationService = xmlSerializationService;
            _fileService = fileService;
        }

        public async Task Output(IFileValidationContext fileValidationContext, Message message, IEnumerable<IValidationError> validationErrors)
        {
            var ilrFileContent = _xmlSerializationService.Serialize(message);

            await _fileService.WriteStringAsync(ilrFileContent, fileValidationContext.OutputFileReference, fileValidationContext.OutputContainer);
        }
    }
}
