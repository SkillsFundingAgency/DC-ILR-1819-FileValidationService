using System;
using System.CodeDom;
using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.TestHelper;
using Moq;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests.Abstract
{
    public abstract class AbstractValidatorTests<TEntity> where TEntity : class
    {
        protected readonly IValidator<TEntity> _validator;

        protected AbstractValidatorTests(IValidator<TEntity> validator)
        {
            _validator = validator;
        }
        
        protected void TestRuleFor<T>(Expression<Func<TEntity, T>> selector, string ruleName, T validValue, T invalidValue)
        {
            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, invalidValue)).WithErrorCode(ruleName);

            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, validValue));
        }

        protected void TestMandatoryStringAttributeRuleFor(Expression<Func<TEntity, string>> selector, string ruleName)
        {
            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, null)).WithErrorCode(ruleName);
            
            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, "Not Null"));
        }

        protected void TestMandatoryLongAttributeRuleFor(Expression<Func<TEntity, long?>> selector, string ruleName)
        {
            _validator.ShouldHaveValidationErrorFor(selector, MockEntity(selector, null)).WithErrorCode(ruleName);

            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, 1));
        }

        private T GetNotNullDefaultValue<T>(Type type)
            where T : class
        {
            switch (type.Name)
            {
                case "String":
                    return "Not Null" as T;
            }

            throw new ArgumentOutOfRangeException();
        }

        protected TEntity MockEntity<T>(Expression<Func<TEntity, T>> selector, T value)
        {
            var learnerMock = new Mock<TEntity>();

            learnerMock.SetupGet(selector).Returns(value);

            return learnerMock.Object;
        }
    }
}
