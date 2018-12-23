using System;
using System.Collections.Generic;
using FluentAssertions;
using PLinq;
using Xunit;

namespace PLinqTests
{
    public class SelectTests
    {
        [Fact]
        public void SelectAndWhereTogether()
        {
            int[] source = {1, 2, 3};
            var result = source.Where(x => x > 1).Select(x => x * 2);
            result.Should().BeEquivalentTo(new[] {4, 6});
        }

        [Fact]
        public void Selecting()
        {
            int[] source = {1, 2, 3};
            var result = source.Select(x => x.ToString());
            result.Should().BeEquivalentTo("1", "2", "3");
        }

        [Fact]
        public void ExecutionIsDeferred()
        {
            ThrowingEnumerable.AssertDeferredThrowsExceptionOnIteration(src => src.Select(x => x.ToString()));
        }


       [Fact]
        public void NullSourceThrouwsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Select(x => x.ToString()));
        }        
        
        [Fact]
        public void NullPredicateThrowsNullArgumentException()
        {
            int[] source = {1, 2, 3};
            Func<int, bool> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Select(selector));
        }       
        
        [Fact]
        public void WithIndexNullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Select((x, index) => (x + 1).ToString()));
        }        
        
        [Fact]
        public void WithIndexNullPredicateThrowsNullArgumentException()
        {
            int[] source = {1, 2, 3, 4, 5, 6, 7};
            Func<int, int, bool> selector = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(selector));
        }

        [Fact]
        public void SelectingWithIndex()
        {
            int[] source = {1, 2, 3};
            var result = source.Select(x => (x + 1).ToString());
            result.Should().BeEquivalentTo("2", "3", "4");
        }
        
    }
}