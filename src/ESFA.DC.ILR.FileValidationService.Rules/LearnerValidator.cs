using System.Text.RegularExpressions;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using FluentValidation.Validators;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerValidator : AbstractValidator<ILooseLearner>
    {
        public LearnerValidator()
        {
            RuleFor(l => l.LearnRefNumber).Matches("[A-Za-z0-9 ]{1,12}", RegexOptions.Compiled).WithErrorCode("FD_LearnRefNumber_AP");

            // RuleFor(l => l.Email).Matches(".+@.+").WithErrorCode("FD_Email_AP");

            //RuleFor(l => l.LearnRefNumber).NotNull().WithErrorCode("FD_LearnRefNumber_MA")
            //    .WithState(l => new[] {_validationErrorHandler.BuildErrorMessageParameter("Test", l.LearnRefNumber)});

            //RuleFor(l => l.PMUKPRN).InclusiveBetween(0, 10000);

            // RuleFor(l => l.ALSCost).Custom(Action);//.Length(1, 3).WithErrorCode("MADE THIS UP")
            //.WithState(l => new[] {_validationErrorHandler.BuildErrorMessageParameter("ALSCost", l.ALSCost)});
        }
    }
}
