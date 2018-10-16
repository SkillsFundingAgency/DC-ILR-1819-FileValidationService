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
            TestRegexRuleFor(esm => esm.ESMType, "FD_ESMType_AP", "ESM Type", "`");
        }

        [Fact]
        public void FD_ESMType_MA()
        {
            TestMandatoryStringAttributeRuleFor(esm => esm.ESMType, "FD_ESMType_MA");
        }

        [Fact]
        public void FD_ESMCode_MA()
        {
            TestMandatoryLongAttributeRuleFor(esm => esm.ESMCodeNullable, "FD_ESMCode_MA");
        }
    }
}
