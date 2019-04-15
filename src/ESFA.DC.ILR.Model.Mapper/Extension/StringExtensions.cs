namespace ESFA.DC.ILR.Model.Mapper.Extension
{
    public static class StringExtensions
    {
        private const string CarriageReturnASCII = "&#13;";

        public static string Sanitize(this string input)
        {
            return input?.Replace(CarriageReturnASCII, string.Empty).Trim();
        }
    }
}
