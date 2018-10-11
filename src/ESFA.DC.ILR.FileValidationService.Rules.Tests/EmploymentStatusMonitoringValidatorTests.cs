using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class EmploymentStatusMonitoringValidatorTests : AbstractValidatorTests<ILooseEmploymentStatusMonitoring>
    {
        public EmploymentStatusMonitoringValidatorTests()
            : base(new EmploymentStatusMonitoringValidator())
        {
        }

        [Fact]
        public void FD_ESMType_AP()
        {
            TestRuleFor(esm => esm.ESMType, "FD_ESMType_AP", "ESM Type", "`");
        }
    }
}
