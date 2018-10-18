﻿using System;

namespace ESFA.DC.ILR.FileValidationService.Rules.Interface
{
    public interface IFileValidationValidator
    {
        void RegexRules();

        void MandatoryAttributeRules();

        void LengthRules();

        void ChildValidators();
    }
}
