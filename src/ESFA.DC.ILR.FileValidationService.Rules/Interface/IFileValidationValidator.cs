using System;

namespace ESFA.DC.ILR.FileValidationService.Rules.Interface
{
    public interface IFileValidationValidator
    {
        void RegexRules();

        void MandatoryRules();

        void LengthRules();

        void ChildValidators();
    }
}
