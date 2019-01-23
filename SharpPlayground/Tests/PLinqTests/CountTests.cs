//#define NORMAL_LINQ

#if NORMAL_LINQ 
using Linq = System.Linq.Enumerable; 
#else 
using Linq = PLinq.EnumberableExtensions;
#endif

using Xunit;
using System.Linq;

namespace PLinqTests
{
    public class CountTests
    {
        [Fact]
        public void NonCollectionCount()
        {
            Assert.Equal(5, Linq.Range(2, 5).Count());
        }

        [Fact]
        public void GenericOnlyCollectionCount()
        {
            ////Assert.Equal(5, new GenericOnlyCollection<int>(Enumerable.Range(2, 5)).Count());
        }

        [Fact]
        public void SemiGenericCollectionCount()
        {
            Assert.Equal(5, new SemiGenericCollection(Enumerable.Range(2, 5)).Count());
        }
    }
}
