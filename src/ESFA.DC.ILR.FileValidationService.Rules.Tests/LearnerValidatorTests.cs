using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerValidatorTests
    {
        [Fact]
        public void Experiment()
        {
            var failures = NewValidator().ShouldHaveValidationErrorFor(l => l.LearnRefNumber, null as string);
        }

        private LearnerValidator NewValidator()
        {
            return new LearnerValidator(new Mock<IValidationErrorHandler>().Object);
        }
    }
}
