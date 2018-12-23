
using System;
using System.Collections.Generic;

namespace PLinq
{
    public static partial class EnumberableExtensions
    {

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return DeferedWhere(source, predicate);
        }

        private static IEnumerable<T> DeferedWhere<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            return DeferredWhere(source, predicate);
        }

        private static IEnumerable<T> DeferredWhere<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            var counter = 0;
            foreach (var item in source)
            {
                if (predicate(item, counter))
                {
                    yield return item;
                }
                counter++;
            }
        }
    }
}
