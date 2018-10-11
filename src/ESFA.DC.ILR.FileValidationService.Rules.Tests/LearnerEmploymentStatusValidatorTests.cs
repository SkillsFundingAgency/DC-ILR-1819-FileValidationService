using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerEmploymentStatusValidatorTests : AbstractValidatorTests<ILooseLearnerEmploymentStatus>
    {
        private static readonly IValidator<ILooseEmploymentStatusMonitoring> EmploymentStatusMonitoringValidator = new Mock<IValidator<ILooseEmploymentStatusMonitoring>>().Object;

        public LearnerEmploymentStatusValidatorTests()
            : base(new LearnerEmploymentStatusValidator(EmploymentStatusMonitoringValidator))
        {
        }

        [Fact]
        public void FD_AgreeId_AP()
        {
            TestRuleFor(esm => esm.AgreeId, "FD_Agree_Id", "ABC123", "");
        }

        [Fact]
        public void EmploymentStatusMonitoring_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(esm => esm.EmploymentStatusMonitorings, typeof(IValidator<ILooseEmploymentStatusMonitoring>));
        }
    }
}
