using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpCMS.UI.Mvc.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var rnd = new Random();
            T[] array = source.ToArray();
            int n = array.Length;
            while (n > 1)
            {
                int k = rnd.Next(n);
                n--;
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }

            return array;
        }

        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }
    }
}