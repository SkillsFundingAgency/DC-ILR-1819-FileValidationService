﻿using System;
using System.Diagnostics;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.ServiceFabric;
using ESFA.DC.JobContextManager.Interface;
using ESFA.DC.JobContextManager.Model;
using ESFA.DC.Queueing;
using ESFA.DC.ServiceFabric.Common.Config;
using ESFA.DC.ServiceFabric.Common.Modules;
using Microsoft.ServiceFabric.Services.Runtime;

namespace ESFA.DC.ILR.FileValidationService.Stateless
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                // The ServiceManifest.XML file defines one or more service type names.
                // Registering a service maps a service type name to a .NET type.
                // When Service Fabric creates an instance of this service type,
                // an instance of the class is created in this host process.

                var builder = BuildContainerBuilder();

                builder.RegisterServiceFabricSupport();

                builder.RegisterStatelessService<ServiceFabric.Common.Stateless>("ESFA.DC.ILR.FileValidationService.StatelessType");

                using (var container = builder.Build())
                {
                    var manager = container.Resolve<IJobContextManager<JobContextMessage>>();

                    ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(ServiceFabric.Common.Stateless).Name);

                    // Prevents this host process from terminating so services keep running.
                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }

        private static ContainerBuilder BuildContainerBuilder()
        {
            var containerBuilder = new ContainerBuilder();

            var serviceFabricConfigurationService = new ServiceFabricConfigurationService();

            var statelessServiceConfiguration = serviceFabricConfigurationService.GetConfigSectionAsStatelessServiceConfiguration();

            var statelessServiceModule = new StatelessServiceModule(statelessServiceConfiguration);

            containerBuilder.RegisterModule(statelessServiceModule);
            containerBuilder.RegisterModule<SerializationModule>();

            containerBuilder.RegisterType<MessageHandler>().As<IMessageHandler<JobContextMessage>>();

            return containerBuilder;
        }
    }
}
