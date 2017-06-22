using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaTracker
{
    public static class ListExtension
    {
        public static IEnumerable<T> OrderBySequence<T, TId>(this IEnumerable<T> source, IEnumerable<TId> order, Func<T, TId> idSelector)
        {
            var lookup = source.ToDictionary(idSelector, t => t);
            foreach (var id in order)
            {
                T value;
                if(lookup.TryGetValue(id, out value))
                {
                    yield return value;
                }
                else
                {
                    throw new Exception("Unknown sort item chain name found.");
                }
            }
        }
    }
}
