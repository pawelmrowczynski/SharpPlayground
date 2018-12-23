using System;
using System.Collections.Generic;
using FluentAssertions;
using PLinq;
using Xunit;

namespace PLinqTests
{
    public class WhereTests
    {
        [Fact]
        public void SimpleFiltering()
        {
            int[] source = {1, 2, 3, 4, 2, 8, 1};
            var result = source.Where(x => x < 4);
            result.Should().BeEquivalentTo(new int[] {1, 2, 3, 2, 1});
        }

        [Fact]
        public void ExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferredThrowsExceptionOnIteration(src => src.Where(x => x > 0));
        }


       [Fact]
        public void NullSourceThrouwsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(x => x == 1));
        }        
        
        [Fact]
        public void NullPredicateThrowsNullArgumentException()
        {
            int[] source = {1, 2, 3, 4, 5, 6, 7};
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }       
        
        [Fact]
        public void WithIndexNullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where((x, index) => x == 1));
        }        
        
        [Fact]
        public void WithIndexNullPredicateThrowsNullArgumentException()
        {
            int[] source = {1, 2, 3, 4, 5, 6, 7};
            Func<int, int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        
        
    }
}