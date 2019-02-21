namespace ESFA.DC.ILR.Model.Mapper.Extension
{
    public static class StringExtensions
    {
        public static string Trim(this string input)
        {
            return input?.TrimStart().TrimEnd();
        }
    }
}
