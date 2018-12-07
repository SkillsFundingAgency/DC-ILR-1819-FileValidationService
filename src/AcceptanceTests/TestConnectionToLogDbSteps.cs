using System;
using System.Configuration;
using System.Data.SqlClient;
using Xunit;
using TechTalk.SpecFlow;

namespace ESFA.DC.ILR.FileValidationService.AcceptanceTests
{
    [Binding]
    [Trait("Category", "SmokeTest")]
    public class TestConnectionToLogDbSteps
    {
        String configItemName = "LoggerConnectionString";
        String DbConnectionString = string.Empty;

        [Given(@"app config ""(.*)"" from the file")]
        public void GivenAppConfigFromTheFile(string ConfigItemName)
        {
            Assert.NotNull(ConfigItemName);
            Assert.NotEmpty(ConfigItemName);
            configItemName = ConfigItemName;

            Assert.NotNull(ConfigurationManager.AppSettings[configItemName]);
            DbConnectionString = ConfigurationManager.AppSettings[configItemName];
        }

        [When(@"I try and Get the Datetime Now")]
        public void WhenITryAndGetTheDatetimeNow()
        {
            using (SqlConnection conn = new SqlConnection(DbConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT GetDate()", conn);
                var DateNow = command.ExecuteScalar();
                Assert.NotNull(DateNow);
            }
        }

    }
}
