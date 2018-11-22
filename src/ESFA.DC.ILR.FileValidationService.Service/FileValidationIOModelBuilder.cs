using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FileValidationService.Service.Interface;
using ESFA.DC.ILR.FileValidationService.Service.Interface.Enum;
using ESFA.DC.ILR.FileValidationService.Service.IO.Model;

namespace ESFA.DC.ILR.FileValidationService.Service
{
    public class FileValidationIOModelBuilder : IFileValidationIOModelBuilder
    {
        public IEnumerable<IO.Model.ValidationError> BuildValidationErrors(IEnumerable<IValidationError> validationErrors)
        {
            return validationErrors?
                .Select(ve =>
                    new IO.Model.ValidationError()
                    {
                        Severity = SeverityToString(ve.Severity),
                        AimSequenceNumber = ve.AimSequenceNumber,
                        LearnerReferenceNumber = ve.LearnerReferenceNumber,
                        RuleName = ve.RuleName,
                        ValidationErrorParameters = ve
                            .ErrorMessageParameters?
                            .Select(p =>
                                new ValidationErrorParameter()
                                {
                                    PropertyName = p.PropertyName,
                                    Value = p.Value,
                                })
                            .ToList()
                    });
            
        }
        public string SeverityToString(Severity? severity)
        {
            switch (severity)
            {
                case Severity.Error:
                    return "E";
                case Severity.Warning:
                    return "W";
                case Severity.Fail:
                    return "F";
                case null:
                    return null;
                default:
                    return null;
            }
        }

    }
}
