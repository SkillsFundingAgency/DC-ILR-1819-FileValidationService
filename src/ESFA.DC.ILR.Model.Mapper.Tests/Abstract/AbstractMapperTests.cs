using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ESFA.DC.ILR.Model.Mapper.Interface;
using FluentAssertions;
using Moq;

namespace ESFA.DC.ILR.Model.Mapper.Tests.Abstract
{
    public abstract class AbstractMapperTests<TIn, TOut>
        where TIn : new()
        where TOut : new()
    {
        protected readonly DateTime TestDateTime = new DateTime(2018, 1, 1);
        protected const string TestString = "TestString";
        protected const int TestInt = 1234567;
        protected const long TestIntSizedLong = 1234567;
        protected const long TestLong = 123455678901;
        protected const decimal TestDecimal = 1.234m;
        protected const bool TestBool = true;
        
        protected void TestMapperProperty<TPropertyIn, TPropertyOut>(IModelMapper<TIn, TOut> mapper, Expression<Func<TIn, TPropertyIn>> inputSelector, TPropertyIn inputValue, Expression<Func<TOut, TPropertyOut>> outputSelector, TPropertyOut outputValue)
        {
            var inputModel = NewInputModelEntity(inputSelector, inputValue);
            var outputModel = mapper.Map(inputModel);
            AssertOutputModel(outputSelector, outputModel, outputValue);
        }

        protected void TestMapperEntityProperty<TPropertyIn, TPropertyOut>(IModelMapper<TIn, TOut> mapper, Expression<Func<TIn, TPropertyIn>> inputSelector, TPropertyIn inputValue, Expression<Func<TOut, TPropertyOut>> outputSelector, TPropertyOut outputValue)
            where TPropertyIn : class
            where TPropertyOut : class
        {
            var inputModel = NewInputModelEntity(inputSelector, inputValue);
            var outputModel = mapper.Map(inputModel);
            AssertOutputModel(outputSelector, outputModel, outputValue);

            var nullInputModel = NewInputModelEntity(inputSelector, null);
            var nullOutputModel = mapper.Map(nullInputModel);
            AssertOutputModel(outputSelector, nullOutputModel, null);
        }

        protected IModelMapper<TPropertyIn, TPropertyOut> NewMockedModelMapper<TPropertyIn, TPropertyOut>(TPropertyIn inputValue, TPropertyOut outputValue)
            where TPropertyIn : class
            where TPropertyOut : class
        {
            var mock = new Mock<IModelMapper<TPropertyIn, TPropertyOut>>();

            mock.Setup(m => m.Map(inputValue)).Returns(outputValue);
            mock.Setup(m => m.Map(null)).Returns(null as TPropertyOut);

            return mock.Object;
        }

        protected void TestMapperCollectionProperty<TPropertyIn, TPropertyOut>(IModelMapper<TIn, TOut> mapper, Expression<Func<TIn, IEnumerable<TPropertyIn>>> inputSelector, IEnumerable<TPropertyIn> inputValue, Expression<Func<TOut, IEnumerable<TPropertyOut>>> outputSelector, IEnumerable<TPropertyOut> outputValue)
            where TPropertyIn : class
            where TPropertyOut : class
        {
            var inputModel = NewInputModelEntity(inputSelector, inputValue);
            var outputModel = mapper.Map(inputModel);
            AssertOutputModelCollectionProperty(outputSelector, outputModel, outputValue);

            var nullInputModel = NewInputModelEntity(inputSelector, null);
            var nullOutputModel = mapper.Map(nullInputModel);
            AssertOutputModelCollectionProperty(outputSelector, nullOutputModel, null);
        }

        protected IModelMapper<TPropertyIn, TPropertyOut> NewMockedModelCollectionMapper<TPropertyIn, TPropertyOut>(IEnumerable<TPropertyIn> inputValues, IEnumerable<TPropertyOut> outputValues)
            where TPropertyIn : class
            where TPropertyOut : class
        {
            var mock = new Mock<IModelMapper<TPropertyIn, TPropertyOut>>();

            var inputArray = inputValues.ToArray();
            var outputArray = outputValues.ToArray();

            inputArray.Should().HaveSameCount(outputArray);

            for (var i = 0; i < inputArray.Length; i++)
            {
                mock.Setup(m => m.Map(inputArray[i])).Returns(outputArray[i]);
            }

            mock.Setup(m => m.Map(null)).Returns(null as TPropertyOut);

            return mock.Object;
        }

        private TIn NewInputModelEntity<TPropertyIn>(Expression<Func<TIn, TPropertyIn>> inputSelector, TPropertyIn inputValue)
        {
            var input = new TIn();

            ((PropertyInfo)((MemberExpression)inputSelector.Body).Member).SetValue(input, inputValue);

            return input;
        }

        protected T[] NewArrayContaining<T>(int count = 5)
            where T : new()
        {
            var list = new List<T>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new T());
            }

            return list.ToArray();
        }

        private void AssertOutputModel<TPropertyOut>(Expression<Func<TOut, TPropertyOut>> outputSelector, TOut outputModel, TPropertyOut expectedOutputValue)
        {
            var selector = outputSelector.Compile();

            var outputValue = selector(outputModel);
                
            outputValue.Should().Be(expectedOutputValue);
        }

        private void AssertOutputModelCollectionProperty<TPropertyOut>(Expression<Func<TOut, IEnumerable<TPropertyOut>>> outputSelector, TOut outputModel, IEnumerable<TPropertyOut> expectedOutputValue)
        {
            var selector = outputSelector.Compile();

            var outputs = selector(outputModel);

            if (expectedOutputValue == null)
            {
                outputs.Should().BeNull();
                return;
            }

            var outputsArray = outputs.ToArray();

            var expectedOutputsArray = expectedOutputValue.ToArray();

            for (var i = 0; i < outputsArray.Length; i++)
            {
                outputsArray[i].Should().Be(expectedOutputsArray[i]);
            }
        }
    }
}
