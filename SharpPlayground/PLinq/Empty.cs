
using System.Collections.Generic;

namespace PLinq
{
    public static partial class EnumberableExtensions
    {

        public static IEnumerable<T> Empty<T>()
        {
            return EmptyHolder<T>.Array;
        }

        private static class EmptyHolder<T>
        {
            internal static readonly T[] Array = new T[0];
        }
    }
}
