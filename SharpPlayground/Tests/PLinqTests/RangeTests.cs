///#define NORMAL_LINQ

#if NORMAL_LINQ 
using Linq = System.Linq.Enumerable; 
#else 
using Linq = PLinq.EnumberableExtensions; 
#endif


using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace PLinqTests
{
    public class RangeTests
    {
        [Fact]
        public void ReturnsValidRange()
        {
            var range = Linq.Range(5, 3);
            range.Should().BeEquivalentTo(new[] {5, 6, 7});

        }

        [Fact]
        public void StartValueCantBeNegative()
        {
            var range = Linq.Range(-3, 2);
            range.Should().BeEquivalentTo(new[] {-3, -2});
        }

        [Fact]
        public void EmptyRangeReturnsEmptyCollection()
        {
            var range = Linq.Range(7, 0);
            range.Should().BeEmpty();
        }

        [Fact]
        public void MaxRangeIsMaximumIntValue()
        {
            var range = Linq.Range(int.MaxValue, 1);
            range.Should().OnlyContain(x => x == int.MaxValue);
            range.Should().HaveCount(1);
        }

        [Fact]
        public void CountCantBeNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Linq.Range(1, -4));
        }

        [Theory]
        [InlineData(int.MaxValue, 4)]
        public void IfCountCrossesMaximumInt_ExceptionIsThrown(int start, int count)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Linq.Range(start, count));
        }
    }
}
