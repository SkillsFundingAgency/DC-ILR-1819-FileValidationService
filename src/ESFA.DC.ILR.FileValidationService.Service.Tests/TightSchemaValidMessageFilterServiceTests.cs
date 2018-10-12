using System.Collections.Generic;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface.Enum;
using ESFA.DC.ILR.Model.Loose;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Service.Tests
{
    public class TightSchemaValidMessageFilterServiceTests
    {
        [Fact]
        public void ApplyFilter()
        {
            var invalidLearnerOneLearnRefNumber = "InvalidOne";
            var invalidLearnerOne = new MessageLearner() { LearnRefNumber = invalidLearnerOneLearnRefNumber };
            var invalidLearnerTwoLearnRefNumber = "InvalidTwo";
            var invalidLearnerTwo = new MessageLearner() { LearnRefNumber = invalidLearnerTwoLearnRefNumber };
            var validLearnerThreeLearnRefNumber = "ValidThree";
            var validLearnerThree = new MessageLearner() { LearnRefNumber = validLearnerThreeLearnRefNumber };
            
            var message = new Message()
            {
                Learner = new []
                {
                    invalidLearnerOne,
                    invalidLearnerTwo,
                    validLearnerThree,
                }
            };

            var validationErrors = new List<IValidationError>()
            {
                new ValidationError.Model.ValidationError() { LearnerReferenceNumber = invalidLearnerOneLearnRefNumber, Severity = Severity.Error },
                new ValidationError.Model.ValidationError() { LearnerReferenceNumber = invalidLearnerTwoLearnRefNumber, Severity = Severity.Error },
                new ValidationError.Model.ValidationError() { LearnerReferenceNumber = invalidLearnerOneLearnRefNumber, Severity = Severity.Error },
                new ValidationError.Model.ValidationError() { LearnerReferenceNumber = validLearnerThreeLearnRefNumber, Severity = Severity.Warning },
            };

            var validMessage = NewService().ApplyFilter(message, validationErrors);

            validMessage.Learner.Should().Contain(validLearnerThree);
            validMessage.Learner.Should().HaveCount(1);
        }

        private TightSchemaValidMessageFilterService NewService()
        {
            return new TightSchemaValidMessageFilterService();
        }
    }
}
