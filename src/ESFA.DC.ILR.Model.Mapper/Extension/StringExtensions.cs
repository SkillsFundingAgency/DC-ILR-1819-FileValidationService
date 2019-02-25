namespace ESFA.DC.ILR.Model.Mapper.Extension
{
    public static class StringExtensions
    {
        public static string Sanitize(this string input)
        {
            return input?.Trim();
        }
    }
}
