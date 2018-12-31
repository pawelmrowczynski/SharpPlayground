//#define NORMAL_LINQ

#if NORMAL_LINQ 
using Linq = System.Linq.Enumerable; 
#else 
using Linq = PLinq.EnumberableExtensions; 
#endif
using Xunit;

namespace PLinqTests
{
    public class EmptyTests
    {
        [Fact]
        public void EmptyContainsNoElements()
        {
            using (var empty = Linq.Empty<int>().GetEnumerator())
            {
                Assert.False(empty.MoveNext());
            }
        }

        [Fact]
        public void EmptyIsASingletonPerElementType()
        {
            Assert.Same(Linq.Empty<int>(), Linq.Empty<int>());
            Assert.Same(Linq.Empty<long>(), Linq.Empty<long>());
            Assert.Same(Linq.Empty<string>(), Linq.Empty<string>());
            Assert.Same(Linq.Empty<object>(), Linq.Empty<object>());

            Assert.NotSame(Linq.Empty<long>(), Linq.Empty<int>());
            Assert.NotSame(Linq.Empty<string>(), Linq.Empty<object>());
        }
    }
}
