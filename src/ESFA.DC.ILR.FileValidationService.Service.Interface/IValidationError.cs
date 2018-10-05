using System.Collections.Generic;
using ESFA.DC.ILR.FileValidationService.Service.Interface.Enum;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IValidationError
    {
        string LearnerReferenceNumber { get; }

        long? AimSequenceNumber { get; }

        string RuleName { get; }

        Severity? Severity { get; }

        IEnumerable<IErrorMessageParameter> ErrorMessageParameters { get; }
    }
}
