using System.Collections.Generic;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface.Enum;

namespace ESFA.DC.ILR.FileValidationService.Service.ValidationError.Model
{
    public class ValidationError : IValidationError
    {
        public ValidationError()
        {
        }

        public ValidationError(string ruleName, string learnerReferenceNumber, long? aimSequenceNumber = null, Severity? severity = null, IEnumerable<IErrorMessageParameter> errorMessageParameters = null)
        {
            LearnerReferenceNumber = learnerReferenceNumber;
            AimSequenceNumber = aimSequenceNumber;
            RuleName = ruleName;
            Severity = severity;
            ErrorMessageParameters = errorMessageParameters;
        }

        public string LearnerReferenceNumber { get; set; }
        public long? AimSequenceNumber { get; set; }
        public string RuleName { get; set; }
        public Severity? Severity { get; set; }
        public IEnumerable<IErrorMessageParameter> ErrorMessageParameters { get; set; }
    }
}
