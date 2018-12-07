using ESFA.DC.ILR.FileValidationService.Service.Interface;

namespace ESFA.DC.ILR.FileValidationService.Service.ValidationError.Model
{
    public class ErrorMessageParameter : IErrorMessageParameter
    {
        public ErrorMessageParameter()
        {
        }

        public ErrorMessageParameter(string propertyName, string value)
        {
            PropertyName = propertyName;
            Value = value;
        }

        public string PropertyName { get; set; }
        public string Value { get; set; }
    }
}
