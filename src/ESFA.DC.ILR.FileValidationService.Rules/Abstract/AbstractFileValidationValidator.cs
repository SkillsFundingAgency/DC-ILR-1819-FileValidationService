using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using ESFA.DC.ILR.FileValidationService.Rules.Interface;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules.Abstract
{
    public abstract class AbstractFileValidationValidator<T> : AbstractValidator<T>, IFileValidationValidator
    {
        protected AbstractFileValidationValidator()
        {
            RuleSet(RuleSetNames.Regex, RegexRules);
            RuleSet(RuleSetNames.MandatoryAttributes, MandatoryAttributeRules);
            RuleSet(RuleSetNames.Length, LengthRules);
            RuleSet(RuleSetNames.Child, ChildValidators);
        }

        public virtual void MandatoryAttributeRules()
        {
        }

        public virtual void RegexRules()
        {
        }

        public virtual void LengthRules()
        {
        }

        public virtual void ChildValidators()
        {
        }
    }
}
