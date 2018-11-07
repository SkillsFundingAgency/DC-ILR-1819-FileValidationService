using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Reflection;
using ESFA.DC.ServiceFabric.Common.Config.Interface;

namespace ESFA.DC.ServiceFabric.Common.Config
{
    public class ServiceFabricConfigurationService : IServiceFabricConfigurationService
    {
        private const string ConfigurationPackageObject = @"Config";
        private const string StatelessServiceConfiguration = @"StatelessServiceConfiguration";
            
        public IDictionary<string, string> GetConfigSectionAsDictionary(string sectionName)
        {
            if (sectionName == null)
            {
                throw new ArgumentNullException(nameof(sectionName));
            }

            return FabricRuntime
                .GetActivationContext()
                .GetConfigurationPackageObject(ConfigurationPackageObject)
                .Settings
                .Sections[sectionName]
                .Parameters
                .ToDictionary(p => p.Name, p => p.Value);
        }

        public T GetConfigSectionAs<T>(string sectionName)
        {
            var returnObject = (T)Activator.CreateInstance(typeof(T));

            var configSectionDictionary = GetConfigSectionAsDictionary(sectionName);

            foreach (var property in returnObject.GetType().GetProperties())
            {
                if (configSectionDictionary.TryGetValue(property.Name, out string value))
                {
                    property.SetValue(returnObject, value);
                }
            }

            return returnObject;
        }

        public IStatelessServiceConfiguration GetConfigSectionAsStatelessServiceConfiguration()
        {
            return GetConfigSectionAs<StatelessServiceConfiguration>(StatelessServiceConfiguration);
        }
    }
}
