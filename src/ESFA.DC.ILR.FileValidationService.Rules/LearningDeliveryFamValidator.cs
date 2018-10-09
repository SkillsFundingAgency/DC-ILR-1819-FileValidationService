using ESFA.DC.ILR.Model.Loose;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearningDeliveryFamValidator : AbstractValidator<MessageLearnerLearningDeliveryLearningDeliveryFAM>
    {
        public LearningDeliveryFamValidator()
        {
            //RuleFor(r => r.LearnDelFAMCode).Null().WithErrorCode("App Fin Type not Null");
        }
    }
}
