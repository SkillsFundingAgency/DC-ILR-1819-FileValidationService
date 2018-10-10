using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.FileService;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Rules;
using ESFA.DC.ILR.FileValidationService.Service;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Loose.Interface;
using ESFA.DC.Mapping.Interface;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Xml;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileValidationContext fileValidationContext = new FileValidationContext()
            {
                FileReference = "ILR-99999999-1819-20180626-144401-01.xml",
                Container = "Files",
                OutputFileReference = "ILR-99999999-1819-20180626-144401-02.xml",
                OutputContainer = "Files"
            };

            IFileService fileService = new FileSystemFileService();
            IXmlSerializationService xmlSerializationService = new XmlSerializationService();

            IValidationErrorHandler validationErrorHandler = new ValidationErrorHandler();
            IValidator<ILooseLearner> learnerValidator = new LearnerValidator();
            IValidator<Model.Loose.MessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFamValidator = new LearningDeliveryFamValidator();
            IValidator<Model.Loose.MessageLearnerLearningDelivery> learningDeliveryValidator = new LearningDeliveryValidator(learningDeliveryFamValidator);

            ILooseMessageProvider looseMessageProvider = new LooseMessageProvider(fileService, xmlSerializationService);
            IFileValidationRuleExecutionService fileValidationRuleExecutionService = new FileValidationRuleExecutionService(learnerValidator, learningDeliveryValidator);
            ITightSchemaValidMessageFilterService tightSchemaValidMessageFilterService = new TightSchemaValidMessageFilterService();
            IMapper<Model.Loose.Message, Message> mapper = new LooseToTightSchemaMapper();
            IFileValidationOutputService fileValidationOutputService = new FileValidationOutputService(xmlSerializationService, fileService);

            IFileValidationOrchestrationService fileValidationOrchestrationService = new FileValidationOrchestrationService(
                looseMessageProvider,
                fileValidationRuleExecutionService,
                tightSchemaValidMessageFilterService,
                mapper,
                fileValidationOutputService);

            fileValidationOrchestrationService.Validate(fileValidationContext, CancellationToken.None).Wait();
        }
    }
}
