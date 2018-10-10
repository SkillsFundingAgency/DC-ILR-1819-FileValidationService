using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FileValidationService.Rules;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.Model.Loose;
using ESFA.DC.ILR.Model.Loose.Interface;
using FluentValidation;
using FluentValidation.Results;
using Severity = ESFA.DC.ILR.FileValidationService.Service.Interface.Enum.Severity;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationRuleExecutionService : IFileValidationRuleExecutionService
    {
        private readonly IValidator<ILooseLearner> _learnerValidator;
        private readonly IValidator<MessageLearnerLearningDelivery> _learningDeliveryValidator;

        public FileValidationRuleExecutionService(IValidator<ILooseLearner> learnerValidator, IValidator<MessageLearnerLearningDelivery> learningDeliveryValidator)
        {
            _learnerValidator = learnerValidator;
            _learningDeliveryValidator = learningDeliveryValidator;
        }

        public IEnumerable<IValidationError> Execute(Message message)
        {
            var validationErrors = new List<IValidationError>();

            if (message?.Learner != null)
            {
                foreach (var learner in message.Learner)
                {
                    var error = _learnerValidator.Validate(learner);

                    validationErrors.AddRange(BuildValidationErrorsFromValidationResult(error, learner.LearnRefNumber));

                    foreach (var learningDelivery in learner.LearningDelivery)
                    {
                        var ldError = _learningDeliveryValidator.Validate(learningDelivery);

                        validationErrors.AddRange(BuildValidationErrorsFromValidationResult(ldError, learner.LearnRefNumber, learningDelivery.AimSeqNumber));
                    }
                }
            }

            return validationErrors;
        }

        private IEnumerable<IValidationError> BuildValidationErrorsFromValidationResult(ValidationResult validationResult, string learnRefNumber, long? aimSequenceNumber = null)
        {
            return validationResult.Errors.Select(e => new ValidationError.Model.ValidationError(e.ErrorCode, learnRefNumber, aimSequenceNumber, Severity.Error, e.CustomState as IEnumerable<IErrorMessageParameter>));
        }
    }
}
