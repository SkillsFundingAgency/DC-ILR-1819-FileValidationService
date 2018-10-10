using System.Text.RegularExpressions;
using ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using FluentValidation.TestHelper;
using Xunit;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests
{
    public class LearnerValidatorTests : AbstractValidatorTests<ILooseLearner>
    {
        public LearnerValidatorTests()
            : base(new LearnerValidator(new ContactPreferenceValidator()))
        {
        }

        [Fact]
        public void FD_LearnRefNumber_AP()
        {
            TestRuleFor(l => l.LearnRefNumber, "FD_LearnRefNumber_AP", "LearnRefNum", "!");
        }

        [Fact]
        public void FD_PrevLearnRefNumber_AP()
        {
            TestRuleFor(l => l.PrevLearnRefNumber, "FD_PrevLearnRefNumber_AP", "LearnRefNum", "!");
        }

        [Fact]
        public void FD_FamilyName_AP()
        {
            TestRuleFor(l => l.FamilyName, "FD_FamilyName_AP", "FamilyName", "");
        }

        [Fact]
        public void FD_GivenNames_AP()
        {
            TestRuleFor(l => l.GivenNames, "FD_GivenNames_AP", "Given Names", "");
        }

        [Fact]
        public void FD_Sex_AP()
        {
            TestRuleFor(l => l.Sex, "FD_Sex_AP", "M", @"`");
        }

        [Fact]
        public void FD_NINumber_AP()
        {
            TestRuleFor(l => l.NINumber, "FD_NINumber_AP", "NINumber", "`");
        }

        [Fact]
        public void FD_MathGrade_AP()
        {
            TestRuleFor(l => l.MathGrade, "FD_MathGrade_AP", "A", "`");
        }

        [Fact]
        public void FD_EngGrade_AP()
        {
            TestRuleFor(l => l.EngGrade, "FD_EngGrade_AP", "A", "`");
        }

        [Fact]
        public void FD_PostcodePrior_AP()
        {
            TestRuleFor(l => l.PostcodePrior, "FD_PostcodePrior_AP", "A12 3BC", "`");
        }

        [Fact]
        public void FD_Postcode_AP()
        {
            TestRuleFor(l => l.Postcode, "FD_Postcode_AP", "A12 3BC", "`");
        }

        [Fact]
        public void FD_AddLine1_AP()
        {
            TestRuleFor(l => l.AddLine1, "FD_AddLine1_AP", "Address Value", "`");
        }

        [Fact]
        public void FD_AddLine2_AP()
        {
            TestRuleFor(l => l.AddLine2, "FD_AddLine2_AP", "Address Value", "`");
        }

        [Fact]
        public void FD_AddLine3_AP()
        {
            TestRuleFor(l => l.AddLine3, "FD_AddLine3_AP", "Address Value", "`");
        }

        [Fact]
        public void FD_AddLine4_AP()
        {
            TestRuleFor(l => l.AddLine4, "FD_AddLine4_AP", "Address Value", "`");
        }

        [Fact]
        public void FD_TelNo_AP()
        {
            TestRuleFor(l => l.TelNo, "FD_TelNo_AP", "012345678910", "ABC");
        }

        [Fact]
        public void FD_Email_AP()
        {
            TestRuleFor(l => l.Email, "FD_Email_AP", "test@test.co.uk", "noAtSign.co.uk");
        }

        [Fact]
        public void FD_CampId_AP()
        {
            TestRuleFor(l => l.CampId, "FD_CampId_AP", "Camp1234", "!");
        }

        [Fact]
        public void ContactPreference_ChildValidator()
        {
            _validator.ShouldHaveChildValidator(l => l.ContactPreferences, typeof(IValidator<ILooseContactPreference>));
        }
    }
}
