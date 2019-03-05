using System.Collections.Generic;
using System.Linq;
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
        private readonly IValidator<ILooseLearningDelivery> _learningDeliveryValidator;
        private readonly IValidator<ILooseLearnerDestinationAndProgression> _learnerDestinationAndProgressionValidator;
        private readonly IValidationErrorHandler _validationErrorHandler;

        public FileValidationRuleExecutionService(
            IValidator<ILooseLearner> learnerValidator,
            IValidator<ILooseLearningDelivery> learningDeliveryValidator,
            IValidator<ILooseLearnerDestinationAndProgression> learnerDestinationAndProgressionValidator,
            IValidationErrorHandler validationErrorHandler)
        {
            _learnerValidator = learnerValidator;
            _learningDeliveryValidator = learningDeliveryValidator;
            _learnerDestinationAndProgressionValidator = learnerDestinationAndProgressionValidator;
            _validationErrorHandler = validationErrorHandler;
        }

        public IEnumerable<IValidationError> Execute(Message message)
        {
            var ruleSet = "*";

            if (message?.Learner != null)
            {
                foreach (var learner in message.Learner)
                {
                    var error = _learnerValidator.Validate(learner, ruleSet: ruleSet);

                    if (!error.IsValid)
                    {
                        HandleValidationErrors(BuildValidationErrorsFromValidationResult(error, learner.LearnRefNumber));
                    }

                    if (learner.LearningDelivery != null)
                    {
                        foreach (var learningDelivery in learner.LearningDelivery)
                        {
                            var ldError = _learningDeliveryValidator.Validate(learningDelivery, ruleSet: ruleSet);

                            if (!ldError.IsValid)
                            {
                                HandleValidationErrors(BuildValidationErrorsFromValidationResult(ldError, learner.LearnRefNumber, learningDelivery.AimSeqNumber));
                            }
                        }
                    }
                }
            }

            if (message?.LearnerDestinationandProgression != null)
            {
                foreach (var learnerDestinationAndProgression in message.LearnerDestinationandProgression)
                {
                    var error = _learnerDestinationAndProgressionValidator.Validate(learnerDestinationAndProgression, ruleSet: ruleSet);

                    if (!error.IsValid)
                    {
                        HandleValidationErrors(BuildValidationErrorsFromValidationResult(error, learnerDestinationAndProgression.LearnRefNumber));
                    }
                }
            };

            return _validationErrorHandler.ValidationErrors;
        }

        private void HandleValidationErrors(IEnumerable<IValidationError> validationErrors)
        {
            _validationErrorHandler.AddRange(validationErrors);
        }

        private IEnumerable<IValidationError> BuildValidationErrorsFromValidationResult(ValidationResult validationResult, string learnRefNumber, long? aimSequenceNumber = null)
        {
            return validationResult.Errors.Select(e => new ValidationError.Model.ValidationError(e.ErrorCode, learnRefNumber, aimSequenceNumber, Severity.Error, e.CustomState as IEnumerable<IErrorMessageParameter>));
        }
    }
}
