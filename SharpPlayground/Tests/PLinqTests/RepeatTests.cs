//#define NORMAL_LINQ

#if NORMAL_LINQ

using Linq = System.Linq.Enumerable; 
#else 
using Linq = PLinq.EnumberableExtensions; 
#endif

using System;
using FluentAssertions;
using Xunit;

namespace PLinqTests
{
    public class RepeatTests
    {
        [Fact]
        public void RepeatsString()
        {
            var repeatSequence = Linq.Repeat("string", 3);
            repeatSequence.Should().BeEquivalentTo("string", "string", "string");

        }

        [Fact]
        public void WhenCount0ReturnsEmptyCollection()
        {
            Linq.Repeat("string", 0).Should().BeEmpty();

        }

        [Fact]
        public void NullValuesAllowed()
        {
            Linq.Repeat<string>(null, 3).Should().BeEquivalentTo(new string[] { null, null, null });

        }

        [Fact]
        public void NegativeCountIsInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Linq.Repeat("string", -8));

        }
    }
}
