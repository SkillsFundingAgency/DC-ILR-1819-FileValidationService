using System;
using System.Linq.Expressions;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerValidatorTests
    {
        [Fact]
        public void FD_LearnRefNumber_AP_Invalid()
        {
            NewValidator().ShouldHaveValidationErrorFor(l => l.LearnRefNumber, MockLearner(l => l.LearnRefNumber, "!")).WithErrorCode("FD_LearnRefNumber_AP");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("LearnRefNum")]
        public void FD_LearnRefNumber_AP_Valid(string learnRefNumber)
        {
            NewValidator().ShouldNotHaveValidationErrorFor(l => l.LearnRefNumber, MockLearner(l => l.LearnRefNumber, learnRefNumber));
        }

        private ILooseLearner MockLearner<T>(Expression<Func<ILooseLearner, T>> selector, T value)
        {
            var learnerMock = new Mock<ILooseLearner>();

            learnerMock.SetupGet(selector).Returns(value);

            return learnerMock.Object;
        }

        private LearnerValidator NewValidator()
        {
            return new LearnerValidator(new Mock<IValidationErrorHandler>().Object);
        }
    }
}
