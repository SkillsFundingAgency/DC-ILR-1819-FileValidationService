using System;
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
            _validator.ShouldHaveValidationErrorFor(selector, this.MockEntity(selector, invalidValue)).WithErrorCode(ruleName);

            _validator.ShouldNotHaveValidationErrorFor(selector, MockEntity(selector, validValue));
        }

        protected TEntity MockEntity<T>(Expression<Func<TEntity, T>> selector, T value)
        {
            var learnerMock = new Mock<TEntity>();

            learnerMock.SetupGet(selector).Returns(value);

            return learnerMock.Object;
        }
    }
}
