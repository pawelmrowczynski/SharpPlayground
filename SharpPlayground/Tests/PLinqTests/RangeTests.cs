#define NORMAL_LINQ

#if NORMAL_LINQ 
using RangeClass = System.Linq.Enumerable; 
#else 
using RangeClass = PLinq.EnumberableExtensions; 
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
            var range = RangeClass.Range(5, 3);
            range.Should().BeEquivalentTo(new[] {5, 6, 7});

        }

        [Fact]
        public void StartValueCantBeNegative()
        {
            var range = RangeClass.Range(-3, 2);
            range.Should().BeEquivalentTo(new[] {-3, -2});
        }

        [Fact]
        public void EmptyRangeReturnsEmptyCollection()
        {
            var range = RangeClass.Range(7, 0);
            range.Should().BeEmpty();
        }

        [Fact]
        public void MaxRangeIsMaximumIntValue()
        {
            var range = RangeClass.Range(int.MaxValue, 1);
            range.Should().OnlyContain(x => x == int.MaxValue);
            range.Should().HaveCount(1);
        }

        [Fact]
        public void CountCantBeNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => RangeClass.Range(1, -4));
        }

        [Theory]
        [InlineData(int.MaxValue, 4)]
        public void IfCountCrossesMaximumInt_ExceptionIsThrown(int start, int range)
        {
            
        }

        
        [Fact]
        public void RangeCanGoUpToMaxInt()
        {
            
        }
    }
}
