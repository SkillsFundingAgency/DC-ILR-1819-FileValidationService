using System;
using System.Configuration;
using Xunit;
using TechTalk.SpecFlow;

namespace ESFA.DC.ILR.FileValidationService.AcceptanceTests
{
    [Binding]
    [Trait("Category", "SmokeTest")]
    public class CheckConfileFileIsBeingPopulatedSteps
    {
        String configItemName = "LoggerConnectionString";

        [Given(@"I have a config file")]
        public void GivenIHaveAConfigFile()
        {
            Assert.NotEmpty (ConfigurationManager.AppSettings);
        }

        [Then(@"Get a ""(.*)"" from the file")]
        public void ThenGetAFromTheFile(string ConfigItemName)
        {
            Assert.NotNull(ConfigItemName);
            Assert.NotEmpty(ConfigItemName);
            configItemName = ConfigItemName;
        }

        [Then(@"the config item should not contain ""(.*)""")]
        public void ThenTheConfigItemShouldNotContain(string tokenValue)
        {
            Assert.NotNull(ConfigurationManager.AppSettings[configItemName]);
            Assert.DoesNotContain(ConfigurationManager.AppSettings[configItemName], tokenValue);
        }
                     
    }
}
