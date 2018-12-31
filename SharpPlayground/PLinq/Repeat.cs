
using System;
using System.Collections.Generic;

namespace PLinq
{
    public static partial class EnumberableExtensions
    {

        public static IEnumerable<T> Repeat<T>(T element, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return DeferedRepeat(element, count);
        }

        private static IEnumerable<T> DeferedRepeat<T>(T element, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return element;
            }
        }
    }
}
