using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose;
using FluentValidation;
using FluentValidation.Validators;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearnerValidator : AbstractValidator<MessageLearner>
    {
        private readonly IValidationErrorHandler _validationErrorHandler;

        public LearnerValidator(IValidationErrorHandler validationErrorHandler)
        {
            _validationErrorHandler = validationErrorHandler;

            RuleFor(l => l.Email).Matches(".+@.+").WithErrorCode("FD_Email_AP");

            //RuleFor(l => l.LearnRefNumber).NotNull().WithErrorCode("FD_LearnRefNumber_MA")
            //    .WithState(l => new[] {_validationErrorHandler.BuildErrorMessageParameter("Test", l.LearnRefNumber)});

            //RuleFor(l => l.PMUKPRN).InclusiveBetween(0, 10000);

            // RuleFor(l => l.ALSCost).Custom(Action);//.Length(1, 3).WithErrorCode("MADE THIS UP")
            //.WithState(l => new[] {_validationErrorHandler.BuildErrorMessageParameter("ALSCost", l.ALSCost)});
        }
    }
}
