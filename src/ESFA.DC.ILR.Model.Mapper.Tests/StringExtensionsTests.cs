using ESFA.DC.ILR.Model.Mapper.Extension;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Trim_NoWhiteSpace()
        {
            StringExtensions.Trim("Word").Should().Be("Word");
        }

        [Fact]
        public void Trim_TrailingWhiteSpace()
        {
            StringExtensions.Trim("Word    ").Should().Be("Word");
        }

        [Fact]
        public void Trim_LeadingWhiteSpace()
        {
            StringExtensions.Trim("    Word").Should().Be("Word");
        }

        [Fact]
        public void Trim_WhiteSpace()
        {
            StringExtensions.Trim("    Word     ").Should().Be("Word");
        }

        [Fact]
        public void Trim_OnlyWhiteSpace()
        {
            StringExtensions.Trim("    ").Should().Be("");
        }

        [Fact]
        public void Trim_Null()
        {
            string word = null;

            StringExtensions.Trim(word).Should().BeNull();
        }

        [Fact]
        public void Trim_Empty()
        {
            StringExtensions.Trim(string.Empty).Should().Be(string.Empty);
        }
    }
}
