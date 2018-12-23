using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PLinqTests
{
    class ThrowingEnumerable : IEnumerable<int>
    {
        internal static void AssertDeferredThrowsExceptionOnIteration<T>(Func<IEnumerable<int>, IEnumerable<T>> deferredFunction)
        {
            ThrowingEnumerable source = new ThrowingEnumerable();
            var result = deferredFunction(source);

            using (var iterator = result.GetEnumerator())
            {
                Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
            }

        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
