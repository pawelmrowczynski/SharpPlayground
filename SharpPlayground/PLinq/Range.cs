
using System;
using System.Collections.Generic;

namespace PLinq
{
    public static partial class EnumberableExtensions
    {

        public static IEnumerable<int> Range(int start, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if ((long)start+(long)count - 1L > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return DeferedRange(start, count);
        }

        private static IEnumerable<int> DeferedRange(int start, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }
    }
}
