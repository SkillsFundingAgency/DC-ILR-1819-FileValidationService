using System;
using System.Diagnostics;
using System.Threading;
using System.Xml.Schema;
using Autofac;
using ESFA.DC.ILR.FileValidationService.Service;
using ESFA.DC.ILR.FileValidationService.Service.Interface;

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
                FileReference = "ILR-10003915-1819-20181206-112643-01.xml",
                Container = "Files",
                OriginalFileReference = "ILR-10003915-1819-20181206-112643-01.xml",
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
                .RegisterValidationServices()
                .RegisterMappers()
                .RegisterLogger();
            
            return containerBuilder;
        }
    }
}
