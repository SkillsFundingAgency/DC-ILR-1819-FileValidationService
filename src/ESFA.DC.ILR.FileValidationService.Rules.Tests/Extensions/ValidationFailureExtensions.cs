using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentValidation.Results;

namespace ESFA.DC.ILR.FileValidationService.Rules.Tests.Extensions
{
    public static class ValidationFailureExtensions
    {
        public static IEnumerable<ValidationFailure> WithLengthState(this IEnumerable<ValidationFailure> validationFailures, string ruleName, string attributeName, object property, int propertyLength)
        {
            var state = validationFailures.First(e => e.ErrorCode == ruleName).CustomState as IDictionary<string, string>;

            state["Length"].Should().Be(propertyLength.ToString());
            state[attributeName].Should().Be(property.ToString());

            return validationFailures;
        }

        public static IEnumerable<ValidationFailure> WithRangeState(this IEnumerable<ValidationFailure> validationFailures, string ruleName, string attributeName, object property)
        {
            var state = validationFailures.First(e => e.ErrorCode == ruleName).CustomState as IDictionary<string, string>;

            state[attributeName].Should().Be(property.ToString());

            return validationFailures;
        }

        public static IEnumerable<ValidationFailure> WithEntityOccurrenceState(this IEnumerable<ValidationFailure> validationFailures, string ruleName, string attributeName, int count)
        {
            var state = validationFailures.First(e => e.ErrorCode == ruleName).CustomState as IDictionary<string, string>;

            state["Actual Occurrences"].Should().Be(count.ToString());

            return validationFailures;
        }
    }
}
