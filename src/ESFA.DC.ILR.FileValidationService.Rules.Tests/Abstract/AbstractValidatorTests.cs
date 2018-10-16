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
        private const string Length = "Length";

        protected readonly IValidator<TEntity> _validator;

        protected const string MandatoryAttributesRuleSetName = "MandatoryAttributes";
        protected const string RegexRuleSetName = "Regex";
        protected const string LengthRuleSetName = "Length";

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

        private string BuildStringOfCharOfLength(int length)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append('A', length);

            return stringBuilder.ToString();
        }

        private long? BuildLongOfStringLength(int length)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append('1', length);

            return length == 0 ? null as long? : long.Parse(stringBuilder.ToString());
        }

        protected TEntity MockEntity<T>(Expression<Func<TEntity, T>> selector, T value)
        {
            var learnerMock = new Mock<TEntity>();

            learnerMock.SetupGet(selector).Returns(value);

            return learnerMock.Object;
        }
    }
}
