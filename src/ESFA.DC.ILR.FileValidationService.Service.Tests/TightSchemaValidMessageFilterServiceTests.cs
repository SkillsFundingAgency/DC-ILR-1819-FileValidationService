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
        public void ApplyFilter_Learner()
        {
            var invalidLearnerOneLearnRefNumber = "InvalidOne";
            var invalidLearnerOne = new MessageLearner() { LearnRefNumber = invalidLearnerOneLearnRefNumber };
            var invalidLearnerTwoLearnRefNumber = "InvalidTwo";
            var invalidLearnerTwo = new MessageLearner() { LearnRefNumber = invalidLearnerTwoLearnRefNumber };
            var validLearnerThreeLearnRefNumber = "ValidThree";
            var validLearnerThree = new MessageLearner() { LearnRefNumber = validLearnerThreeLearnRefNumber };
            string invalidLearnerThreeNullLearnRefNumber = null;
            var invalidLearnerThree = new MessageLearner() { LearnRefNumber = invalidLearnerThreeNullLearnRefNumber };

            var message = new Message()
            {
                Learner = new []
                {
                    invalidLearnerOne,
                    invalidLearnerTwo,
                    validLearnerThree,
                    invalidLearnerThree,
                }
            };

            var validationErrors = new List<IValidationError>()
            {
                new ValidationError.Model.ValidationError() { LearnerReferenceNumber = invalidLearnerOneLearnRefNumber, Severity = Severity.Error },
                new ValidationError.Model.ValidationError() { LearnerReferenceNumber = invalidLearnerTwoLearnRefNumber, Severity = Severity.Error },
                new ValidationError.Model.ValidationError() { LearnerReferenceNumber = invalidLearnerOneLearnRefNumber, Severity = Severity.Error },
                new ValidationError.Model.ValidationError() { LearnerReferenceNumber = validLearnerThreeLearnRefNumber, Severity = Severity.Warning },
                new ValidationError.Model.ValidationError() { LearnerReferenceNumber = invalidLearnerThreeNullLearnRefNumber, Severity = Severity.Error },
            };

            var validMessage = NewService().ApplyFilter(message, validationErrors);

            validMessage.Learner.Should().Contain(validLearnerThree);
            validMessage.Learner.Should().HaveCount(1);
        }

        [Fact]
        public void ApplyFilter_NullLearner()
        {
            var message = new Message()
            {
                Learner = null
            };

            var validMessage = NewService().ApplyFilter(message, new List<IValidationError>());

            validMessage.Learner.Should().BeNull();
        }

        [Fact]
        public void ApplyFilter_LearnerDestinationAndProgression()
        {
            var invalidLearnerOneLearnRefNumber = "InvalidOne";
            var invalidLearnerOne = new MessageLearnerDestinationandProgression() { LearnRefNumber = invalidLearnerOneLearnRefNumber };
            var invalidLearnerTwoLearnRefNumber = "InvalidTwo";
            var invalidLearnerTwo = new MessageLearnerDestinationandProgression() { LearnRefNumber = invalidLearnerTwoLearnRefNumber };
            var validLearnerThreeLearnRefNumber = "ValidThree";
            var validLearnerThree = new MessageLearnerDestinationandProgression() { LearnRefNumber = validLearnerThreeLearnRefNumber };

            var message = new Message()
            {
                LearnerDestinationandProgression = new[]
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

            validMessage.LearnerDestinationandProgression.Should().Contain(validLearnerThree);
            validMessage.LearnerDestinationandProgression.Should().HaveCount(1);
        }

        [Fact]
        public void ApplyFilter_NullLearnerDestinationAndProgression()
        {
            var message = new Message()
            {
                LearnerDestinationandProgression = null
            };

            var validMessage = NewService().ApplyFilter(message, new List<IValidationError>());

            validMessage.LearnerDestinationandProgression.Should().BeNull();
        }

        private TightSchemaValidMessageFilterService NewService()
        {
            return new TightSchemaValidMessageFilterService();
        }
    }
}
