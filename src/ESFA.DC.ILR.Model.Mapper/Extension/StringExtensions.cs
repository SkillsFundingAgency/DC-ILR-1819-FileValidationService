using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR.Model.Mapper.Extension
{
    public static class StringExtensions
    {
        public static string Sanitize(this string input)
        {
            return input?.TrimEnd();
        }
    }
}
