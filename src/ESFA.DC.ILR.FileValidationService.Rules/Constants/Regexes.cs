namespace ESFA.DC.ILR.FileValidationService.Rules.Constants
{
    public static class Regexes
    {
        public const string RestrictedString = @"^[A-Za-z0-9 .,;:~!""@#$%&'()\\\/*+-<=>?_[\]{}^£€]*$";
        public const string LearnRefNumber = @"^[A-Za-z0-9 ]{1,12}$";
        public const string Name = @"^[^0-9\r\n\t|""]{1,100}$";
        public const string Address = @"^[A-Za-z0-9 ~!@&'\\()*+,-./:;]{1,50}$";
        public const string TelephoneNumber = @"^[0-9]{1,18}$";
        public const string EmailAddress = @"^.+@.+$";
        public const string CampId = @"^[A-Za-z0-9]{1,8}$";
        public const string UcasPerId = @"[0-9]{10}";
    }
}
