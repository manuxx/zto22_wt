using System.Collections.Generic;

namespace Training.DomainClasses
{
    internal static class Utils
    {
        public static IEnumerable<TItem> EachElement<TItem>(this IEnumerable<TItem> collection)
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }
    }
}