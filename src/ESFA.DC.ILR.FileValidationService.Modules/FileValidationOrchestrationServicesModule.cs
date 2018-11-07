using Autofac;
using ESFA.DC.ILR.FileValidationService.Service;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Loose.Schema;
using ESFA.DC.ILR.Model.Loose.Schema.Interface;
using ESFA.DC.Mapping.Interface;

namespace ESFA.DC.ILR.FileValidationService.Modules
{
    public class FileValidationOrchestrationServicesModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ValidationErrorHandler>().As<IValidationErrorHandler>();
            containerBuilder.RegisterType<IlrLooseXmlSchemaProvider>().As<IIlrLooseXmlSchemaProvider>();
            containerBuilder.RegisterType<ValidationErrorMetadataService>().As<IValidationErrorMetadataService>();
            containerBuilder.RegisterType<XsdValidationService>().As<IXsdValidationService>();
            containerBuilder.RegisterType<LooseMessageProvider>().As<ILooseMessageProvider>();
            containerBuilder.RegisterType<FileValidationRuleExecutionService>().As<IFileValidationRuleExecutionService>();
            containerBuilder.RegisterType<TightSchemaValidMessageFilterService>().As<ITightSchemaValidMessageFilterService>();
            containerBuilder.RegisterType<LooseToTightSchemaMapper>().As<IMapper<Model.Loose.Message, Message>>();
            containerBuilder.RegisterType<FileValidationOutputService>().As<IFileValidationOutputService>();
            containerBuilder.RegisterType<FileValidationOrchestrationService>().As<IFileValidationOrchestrationService>();
        }
    }
}
