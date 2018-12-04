using System;
using Xunit;
using TechTalk.SpecFlow;

namespace ESFA.DC.ILR.FileValidationService.AcceptanceTests
{
    [Binding]
    [Trait("Category", "SmokeTest")]
    [Trait("Category", "Bob")]
    [Trait("Category", "NonDestructive")]
    public class FakeTestToTestReleasePipelineSteps
    {
        private int result;
        private FakeTest.Calculator calculator = new FakeTest.Calculator();

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            calculator.FirstNumber = number;
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            calculator.SecondNumber = number;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            result = calculator.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Assert.Equal(expectedResult, result);
        }
    }
}


namespace FakeTest
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
    }

}