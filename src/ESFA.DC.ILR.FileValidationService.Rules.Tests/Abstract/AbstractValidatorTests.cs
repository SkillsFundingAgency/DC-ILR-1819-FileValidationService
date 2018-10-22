using System;
using System.Linq.Expressions;
using System.Text;
using ESFA.DC.ILR.FileValidationService.Rules.Tests.Extensions;
using FluentValidation;
using FluentValidation.TestHelper;
using Moq;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract
{
    public abstract class AbstractValidatorTests<TEntity> where TEntity : class
    {
        protected readonly IValidator<TEntity> _validator;

        private const string MandatoryAttributesRuleSetName = "MandatoryAttributes";
        private const string RegexRuleSetName = "Regex";
        private const string LengthRuleSetName = "Length";
        private const string RangeRuleSetName = "Range";

        protected AbstractValidatorTests(IValidator<TEntity> validator)
        {
            _validator = validator;
        }
        
        protected void TestRegexRuleFor<T>(Expression<Func<TEntity, T>> selector, string ruleName, T validValue, T invalidValue)
        {
            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, invalidValue), RegexRuleSetName).WithErrorCode(ruleName);
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, validValue), RegexRuleSetName);
        }

        protected void TestMandatoryStringAttributeRuleFor(Expression<Func<TEntity, string>> selector, string ruleName)
        {
            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, null), MandatoryAttributesRuleSetName).WithErrorCode(ruleName);
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, "Not Null"), MandatoryAttributesRuleSetName);
        }

        protected void TestMandatoryLongAttributeRuleFor(Expression<Func<TEntity, long?>> selector, string ruleName)
        {
            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, null), MandatoryAttributesRuleSetName).WithErrorCode(ruleName);
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, 1), MandatoryAttributesRuleSetName);
        }

        protected void TestMandatoryDateTimeAttributeRuleFor(Expression<Func<TEntity, DateTime?>> selector, string ruleName)
        {
            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, null), MandatoryAttributesRuleSetName).WithErrorCode(ruleName);
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, new DateTime(2018, 1, 1)), MandatoryAttributesRuleSetName);
        }

        protected void TestLengthStringRuleFor(Expression<Func<TEntity, string>> selector, string ruleName, string attributeName, int lowerLength, int upperLength)
        {
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, BuildStringOfCharOfLength(lowerLength)), LengthRuleSetName);
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, BuildStringOfCharOfLength(upperLength)), LengthRuleSetName);

            var lowerInvalidLength = lowerLength - 1;
            var upperInvalidLength = upperLength + 1;

            if (lowerLength > 0)
            {
                var lowerInvalidString = BuildStringOfCharOfLength(lowerInvalidLength);

                _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, lowerInvalidString),
                        LengthRuleSetName)
                    .WithErrorCode(ruleName)
                    .WithLengthState(ruleName, attributeName, lowerInvalidString, lowerInvalidLength);
            }

            var upperInvalidString = BuildStringOfCharOfLength(upperInvalidLength);

            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, upperInvalidString), LengthRuleSetName)
                .WithErrorCode(ruleName)
                .WithLengthState(ruleName, attributeName, upperInvalidString, upperInvalidLength);
        }

        protected void TestLengthLongRuleFor(Expression<Func<TEntity, long?>> selector, string ruleName, string attributeName, int lowerLength, int upperLength)
        {
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, BuildLongOfStringLength(lowerLength)), LengthRuleSetName);
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, BuildLongOfStringLength(upperLength)), LengthRuleSetName);

            var lowerInvalidLength = lowerLength - 1;
            var upperInvalidLength = upperLength + 1;

            var lowerInvalidLong = BuildLongOfStringLength(lowerInvalidLength);
            var upperInvalidLong = BuildLongOfStringLength(upperInvalidLength);

            if (lowerLength > 1)
            {
                _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, lowerInvalidLong), LengthRuleSetName)
                    .WithErrorCode(ruleName)
                    .WithLengthState(ruleName, attributeName, lowerInvalidLong, lowerInvalidLength); 
            }

            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, upperInvalidLong), LengthRuleSetName)
                .WithErrorCode(ruleName)
                .WithLengthState(ruleName, attributeName, upperInvalidLong, upperInvalidLength);
        }

        protected void TestLengthDecimalRuleFor(Expression<Func<TEntity, decimal?>> selector, string ruleName, string attributeName, int precision, int scale)
        {
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, BuildDecimalOfPrecisionScale(1, 0)), LengthRuleSetName);
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, BuildDecimalOfPrecisionScale(precision, scale)), LengthRuleSetName);

            var precisionIncrementDecimal = BuildDecimalOfPrecisionScale(precision + 1, scale);
            var scaleIncrementDecimal = BuildDecimalOfPrecisionScale(precision, scale + 1);

            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, precisionIncrementDecimal), LengthRuleSetName)
                .WithErrorCode(ruleName)
                .WithLengthState(ruleName, attributeName, precisionIncrementDecimal, precisionIncrementDecimal.ToString().Length);

            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, scaleIncrementDecimal), LengthRuleSetName)
                .WithErrorCode(ruleName)
                .WithLengthState(ruleName, attributeName, scaleIncrementDecimal, scaleIncrementDecimal.ToString().Length);
        }

        protected void TestRangeFor(Expression<Func<TEntity, long?>> selector, string ruleName, string attributeName, long minimum, long maximum)
        {
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, minimum), RangeRuleSetName);
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, maximum), RangeRuleSetName);

            var invalidMinimum = minimum - 1;

            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, invalidMinimum), RangeRuleSetName)
                .WithErrorCode(ruleName)
                .WithRangeState(ruleName, attributeName, invalidMinimum);

            var invalidMaximum = maximum + 1;

            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, invalidMaximum), RangeRuleSetName)
                .WithErrorCode(ruleName)
                .WithRangeState(ruleName, attributeName, invalidMaximum);
        }

        protected void TestRangeFor(Expression<Func<TEntity, decimal?>> selector, string ruleName, string attributeName, decimal minimum, decimal maximum)
        {
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, minimum), RangeRuleSetName);
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, maximum), RangeRuleSetName);

            var invalidMinimum = minimum - 0.0001m;

            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, invalidMinimum), RangeRuleSetName)
                .WithErrorCode(ruleName)
                .WithRangeState(ruleName, attributeName, invalidMinimum);

            var invalidMaximum = maximum + 0.0001m;

            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, invalidMaximum), RangeRuleSetName)
                .WithErrorCode(ruleName)
                .WithRangeState(ruleName, attributeName, invalidMaximum);
        }

        protected void TestRangeForStringAsLong(Expression<Func<TEntity, string>> selector, string ruleName, string attributeName, long minimum, long maximum)
        {
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, minimum.ToString()), RangeRuleSetName);
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, maximum.ToString()), RangeRuleSetName);

            var invalidMinimum = (minimum - 1).ToString();

            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, invalidMinimum), RangeRuleSetName)
                .WithErrorCode(ruleName)
                .WithRangeState(ruleName, attributeName, invalidMinimum);

            var invalidMaximum = (maximum + 1).ToString();

            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, invalidMaximum), RangeRuleSetName)
                .WithErrorCode(ruleName)
                .WithRangeState(ruleName, attributeName, invalidMaximum);
        }

        private decimal BuildDecimalOfPrecisionScale(int precision, int scale)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(BuildStringOfCharOfLength(precision - scale, '1'));

            if (scale > 0)
            {
                stringBuilder.Append(".");
                stringBuilder.Append(BuildStringOfCharOfLength(scale, '1'));
            }

            return decimal.Parse(stringBuilder.ToString());
        }

        private string BuildStringOfCharOfLength(int length, char character = 'A')
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(character, length);

            return stringBuilder.ToString();
        }

        private long? BuildLongOfStringLength(int length)
        {
            return length == 0 ? null as long? : long.Parse(BuildStringOfCharOfLength(length, '1'));
        }

        protected TEntity MockEntity<T>(Expression<Func<TEntity, T>> selector, T value)
        {
            var learnerMock = new Mock<TEntity>();

            learnerMock.SetupGet(selector).Returns(value);

            return learnerMock.Object;
        }
    }
}
