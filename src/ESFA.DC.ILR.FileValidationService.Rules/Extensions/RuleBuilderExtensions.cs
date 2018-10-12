using System.Text.RegularExpressions;
using ESFA.DC.ILR.FileValidationService.Rules.Constants;
using FluentValidation;

namespace ESFA.DC.ILR.FileValidationService.Rules.Extensions
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, string> MatchesRestrictedString<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.MatchesRegex(Regexes.RestrictedString);
        }

        public static IRuleBuilderOptions<T, string> MatchesRegex<T>(this IRuleBuilder<T, string> ruleBuilder, string expression)
        {
            return ruleBuilder.Matches(expression, RegexOptions.Compiled);
        }
    }
}
