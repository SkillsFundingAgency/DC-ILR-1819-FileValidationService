using ESFA.DC.ILR.Model.Mapper.Extension;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Mapper.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Sanitize_NoWhiteSpace()
        {
            "Word".Sanitize().Should().Be("Word");
        }

        [Fact]
        public void Sanitize_TrailingWhiteSpace()
        {
            "Word    ".Sanitize().Should().Be("Word");
        }

        [Fact]
        public void Sanitize_LeadingWhiteSpace()
        {
            "    Word".Sanitize().Should().Be("Word");
        }

        [Fact]
        public void Sanitize_WhiteSpace()
        {
            "    Word     ".Sanitize().Should().Be("Word");
        }

        [Fact]
        public void Sanitize_OnlyWhiteSpace()
        {
            "    ".Sanitize().Should().Be("");
        }

        [Fact]
        public void Sanitize_Null()
        {
            string word = null;

            word.Sanitize().Should().BeNull();
        }

        [Fact]
        public void Sanitize_Empty()
        {
            string.Empty.Sanitize().Should().Be(string.Empty);
        }

        [Fact]
        public void Sanitize_CarriageReturn()
        {
            "Word&#13;".Sanitize().Should().Be("Word");
        }
    }
}
