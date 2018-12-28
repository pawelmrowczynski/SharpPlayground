//#define NORMAL_LINQ

#if NORMAL_LINQ 
using EmptyClass = System.Linq.Enumerable; 
#else 
using EmptyClass = PLinq.EnumberableExtensions; 
#endif
using Xunit;

namespace PLinqTests
{
    public class EmptyTests
    {
        [Fact]
        public void EmptyContainsNoElements()
        {
            using (var empty = EmptyClass.Empty<int>().GetEnumerator())
            {
                Assert.False(empty.MoveNext());
            }
        }

        [Fact]
        public void EmptyIsASingletonPerElementType()
        {
            Assert.Same(EmptyClass.Empty<int>(), EmptyClass.Empty<int>());
            Assert.Same(EmptyClass.Empty<long>(), EmptyClass.Empty<long>());
            Assert.Same(EmptyClass.Empty<string>(), EmptyClass.Empty<string>());
            Assert.Same(EmptyClass.Empty<object>(), EmptyClass.Empty<object>());

            Assert.NotSame(EmptyClass.Empty<long>(), EmptyClass.Empty<int>());
            Assert.NotSame(EmptyClass.Empty<string>(), EmptyClass.Empty<object>());
        }
    }
}
