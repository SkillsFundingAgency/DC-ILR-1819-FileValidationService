﻿using System.Collections.Generic;
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

        public static IRuleBuilderOptions<T, long?> Length<T>(this IRuleBuilder<T, long?> ruleBuilder, int lowerLength, int upperLength)
        {
            return ruleBuilder.Must(p =>
            {
                if (!p.HasValue)
                {
                    return true;
                }

                var length = p.ToString().Length;

                return length >= lowerLength && length <= upperLength;
            });
        }

        public static IRuleBuilderOptions<T, decimal?> DecimalLength<T>(this IRuleBuilder<T, decimal?> ruleBuilder, int precision, int scale)
        {
            return ruleBuilder.Must(p =>
            {
                if (!p.HasValue)
                {
                    return true;
                }

                var decimalString = p.ToString();

                if (decimalString.Length > precision + 1)
                {
                    return false;
                }

                var decimalSplit = decimalString.Split('.');

                if (decimalSplit[0].Length > precision - scale)
                {
                    return false;
                }

                if (decimalSplit.Length > 1 && decimalSplit[1].Length > scale)
                {
                    return false;
                }

                return true;
            });
        }

        public static IRuleBuilderOptions<T, TProperty> WithLengthError<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilderOptions, string ruleName)
        {
            return ruleBuilderOptions
                .WithErrorCode(ruleName)
                .WithLengthState(ExtractPropertyName(ruleName));
        }

        public static IRuleBuilderOptions<T, TProperty> WithRangeError<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilderOptions, string ruleName)
        {
            return ruleBuilderOptions
                .WithErrorCode(ruleName)
                .WithRangeState(ExtractPropertyName(ruleName));
        }

        private static IRuleBuilderOptions<T, TProperty> WithLengthState<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilderOptions, string attributeName)
        {
            return ruleBuilderOptions.WithState((t, p) =>
                new Dictionary<string, string>()
                {
                    { attributeName, p?.ToString() },
                    { "Length", p?.ToString().Length.ToString() }
                });
        }

        private static IRuleBuilderOptions<T, TProperty> WithRangeState<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> ruleBuilderOptions, string attributeName)
        {
            return ruleBuilderOptions.WithState((t, p) =>
                new Dictionary<string, string>()
                {
                    { attributeName, p?.ToString() },
                });
        }

        private static string ExtractPropertyName(string ruleName)
        {
            var ruleNameSplit = ruleName.Split('_');

            return ruleNameSplit[ruleNameSplit.Length - 2];
        }
    }
}
