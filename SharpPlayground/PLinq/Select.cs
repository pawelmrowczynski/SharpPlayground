
using System;
using System.Collections;
using System.Collections.Generic;

namespace PLinq
{
    public static partial class EnumberableExtensions
    {

        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return DeferredSelect(source, selector);
        }

        private static IEnumerable<TResult> DeferredSelect<T, TResult>(IEnumerable<T> source, Func<T, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, int, TResult> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return DeferredSelect(source, selector);
        }

        private static IEnumerable<TResult> DeferredSelect<T, TResult>(IEnumerable<T> source, Func<T, int, TResult> selector)
        {
            var counter = 0;
            foreach (var item in source)
            {
                yield return selector(item, counter);
                counter++;
            }
        }
    }
}
