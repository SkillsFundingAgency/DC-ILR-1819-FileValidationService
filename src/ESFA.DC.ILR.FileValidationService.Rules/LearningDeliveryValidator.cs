using ESFA.DC.ILR.Model.Loose;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules
{
    public class LearningDeliveryValidator : AbstractValidator<MessageLearnerLearningDelivery>
    {
        private readonly IValidator<MessageLearnerLearningDeliveryLearningDeliveryFAM> _learningDeliveryFamValidator;

        public LearningDeliveryValidator(IValidator<MessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFamValidator)
        {
            _learningDeliveryFamValidator = learningDeliveryFamValidator;

            //RuleFor(ld => ld.LearnAimRef).NotNull().WithErrorCode("LEARN AIM REF NULL");

            //RuleForEach(ld => ld.LearningDeliveryFAM).SetValidator(_learningDeliveryFamValidator);
        }
    }
}
