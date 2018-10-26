using System;
using System.Diagnostics;
using System.Threading;
using System.Xml.Schema;
using Autofac;
using ESFA.DC.FileService;
using ESFA.DC.FileService.Config;
using ESFA.DC.FileService.Config.Interface;
using ESFA.DC.FileService.Interface;
using ESFA.DC.ILR.FileValidationService.Rules;
using ESFA.DC.ILR.FileValidationService.Service;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Loose.Interface;
using ESFA.DC.ILR.Model.Loose.Schema;
using ESFA.DC.ILR.Model.Loose.Schema.Interface;
using ESFA.DC.IO.Dictionary;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Mapping.Interface;
using ESFA.DC.Serialization.Interfaces;
using ESFA.DC.Serialization.Json;
using ESFA.DC.Serialization.Xml;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            IFileValidationContext fileValidationContext = new FileValidationContext()
            {
                FileReference = "ILR-99999999-1819-20180626-144401-01.xml",
                Container = "Files",
                OutputFileReference = "ILR-99999999-1819-20180626-144401-02.xml",
                ValidationErrorsKey = "ValidationErrors"
            };

            //IFileValidationContext fileValidationContext = new FileValidationContext()
            //{
            //    FileReference = @"10003231/ILR-10003231-1819-20181012-100001-01.xml",
            //    Container = "ilr-files",
            //    OutputFileReference = @"10003231/ILR-10003231-1819-20181012-100001-02.xml",
            //    OutputContainer = "ilr-files"
            //};

            //IAzureStorageFileServiceConfig azureStorageFileServiceConfig = new AzureStorageFileServiceConfig()
            //{
            //    ConnectionString = ""
            //};
            //IFileService fileService = new AzureStorageFileService(azureStorageFileServiceConfig);

            var container = CreateContainerBuilder().Build();
            
            var fileValidationOrchestrationService = container.Resolve<IFileValidationOrchestrationService>();

            try
            {
                fileValidationOrchestrationService.Validate(fileValidationContext, CancellationToken.None).Wait();

                System.Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
                System.Console.Read();
            }
            catch (AggregateException aggregateException) when (aggregateException.InnerException is XmlSchemaException)
            {
                // Error Handle. Abort Job, go do XSD Validation Report.
            }
            catch(Exception exception)
            {
                // Job Failed
            }
        }

        private static ContainerBuilder CreateContainerBuilder()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder
                .RegisterValidators()
                .RegisterSerializers()
                .RegisterIoServices()
                .RegisterValidationServices();
            
            return containerBuilder;
        }
    }
}
