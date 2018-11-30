using System;
using TechTalk.SpecFlow;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.AcceptanceTests
{
    [Binding]
    public class SubmitTestILRFileSteps
    {
        private int result;
        private FakeTest.Calculator calculator = new FakeTest.Calculator();

        [Given(@"I have Created a file")]
        public void GivenIHaveCreatedAFile()
        {
            calculator.FirstNumber = 52;
        }

        [Given(@"I have entered Create a message")]
        public void GivenIHaveEnteredCreateAMessage()
        {
            calculator.SecondNumber = 82;
        }
        
        [When(@"I submit the Message to Service Bus")]
        public void WhenISubmitTheMessageToServiceBus()
        {
            result = calculator.Add();
        }
        
        [Then(@"the result file shoulf be in storage")]
        public void ThenTheResultFileShoulfBeInStorage()
        {
            Assert.Equal(134, result);
        }
    }
}
