using System.Text.RegularExpressions;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Extensions;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerValidator : AbstractValidator<ILooseLearner>
    {
        private readonly IValidator<ILooseContactPreference> _contactPreferenceValidator;

        public LearnerValidator(IValidator<ILooseContactPreference> contactPreferenceValidator)
        {
            _contactPreferenceValidator = contactPreferenceValidator;

            RuleFor(l => l.LearnRefNumber).MatchesRegex("^[A-Za-z0-9 ]{1,12}$").WithErrorCode(RuleNames.FD_LearnRefNumber_AP);
            RuleFor(l => l.PrevLearnRefNumber).MatchesRegex("^[A-Za-z0-9 ]{1,12}$").WithErrorCode(RuleNames.FD_PrevLearnRefNumber_AP);
            RuleFor(l => l.FamilyName).MatchesRegex(@"^[^0-9\r\n\t|&quot;]{1,100}$").WithErrorCode(RuleNames.FD_FamilyName_AP);
            RuleFor(l => l.GivenNames).MatchesRegex(@"^[^0-9\r\n\t|&quot;]{1,100}$").WithErrorCode(RuleNames.FD_GivenNames_AP);
            RuleFor(l => l.Sex).MatchesRegex(@"^[A-Za-z0-9 ~!@#$%&amp;'\(\)\*\+,\-\./:;&lt;=&gt;\?\[\\\]_\{\}\^&#xa3;&#x20ac;]*$").WithErrorCode(RuleNames.FD_Sex_AP);
            RuleFor(l => l.NINumber).MatchesRegex(@"^[A-Za-z0-9 ~!@#$%&amp;'\(\)\*\+,\-\./:;&lt;=&gt;\?\[\\\]_\{\}\^&#xa3;&#x20ac;]*$").WithErrorCode(RuleNames.FD_NINumber_AP);
            RuleFor(l => l.MathGrade).MatchesRegex(@"^[A-Za-z0-9 ~!@#$%&amp;'\(\)\*\+,\-\./:;&lt;=&gt;\?\[\\\]_\{\}\^&#xa3;&#x20ac;]*$").WithErrorCode(RuleNames.FD_MathGrade_AP);
            RuleFor(l => l.EngGrade).MatchesRegex(@"^[A-Za-z0-9 ~!@#$%&amp;'\(\)\*\+,\-\./:;&lt;=&gt;\?\[\\\]_\{\}\^&#xa3;&#x20ac;]*$").WithErrorCode(RuleNames.FD_EngGrade_AP);
            RuleFor(l => l.PostcodePrior).MatchesRegex(@"^[A-Za-z0-9 ~!@#$%&amp;'\(\)\*\+,\-\./:;&lt;=&gt;\?\[\\\]_\{\}\^&#xa3;&#x20ac;]*$").WithErrorCode(RuleNames.FD_PostcodePrior_AP);
            RuleFor(l => l.Postcode).MatchesRegex(@"^[A-Za-z0-9 ~!@#$%&amp;'\(\)\*\+,\-\./:;&lt;=&gt;\?\[\\\]_\{\}\^&#xa3;&#x20ac;]*$").WithErrorCode(RuleNames.FD_Postcode_AP);
            RuleFor(l => l.AddLine1).MatchesRegex(@"^[A-Za-z0-9 ~!@&amp;'\\()*+,\-./:;]{1,50}$").WithErrorCode(RuleNames.FD_AddLine1_AP);
            RuleFor(l => l.AddLine2).MatchesRegex(@"^[A-Za-z0-9 ~!@&amp;'\\()*+,\-./:;]{1,50}$").WithErrorCode(RuleNames.FD_AddLine2_AP);
            RuleFor(l => l.AddLine3).MatchesRegex(@"^[A-Za-z0-9 ~!@&amp;'\\()*+,\-./:;]{1,50}$").WithErrorCode(RuleNames.FD_AddLine3_AP);
            RuleFor(l => l.AddLine4).MatchesRegex(@"^[A-Za-z0-9 ~!@&amp;'\\()*+,\-./:;]{1,50}$").WithErrorCode(RuleNames.FD_AddLine4_AP);
            RuleFor(l => l.TelNo).MatchesRegex("^[0-9]{1,18}$").WithErrorCode(RuleNames.FD_TelNo_AP);
            RuleFor(l => l.Email).MatchesRegex("^.+@.+$").WithErrorCode(RuleNames.FD_Email_AP);
            RuleFor(l => l.CampId).MatchesRegex("^[A-Za-z0-9]{1,8}$").WithErrorCode(RuleNames.FD_CampId_AP);

            RuleForEach(l => l.ContactPreferences).SetValidator(_contactPreferenceValidator);
        }
    }
}
