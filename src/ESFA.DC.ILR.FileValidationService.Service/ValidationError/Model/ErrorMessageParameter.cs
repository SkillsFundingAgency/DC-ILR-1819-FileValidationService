using System;
using System.Collections.Generic;
using System.Text;
using ESFA.DC.ILR.FileValidationService.Service.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service.ValidationError.Model
{
    public class ErrorMessageParameter : IErrorMessageParameter
    {
        public string PropertyName { get; set; }
        public string Value { get; set; }
    }
}
