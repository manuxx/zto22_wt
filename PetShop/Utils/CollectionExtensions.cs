namespace Training.DomainClasses.Utils
{
    using System;
    using System.Collections.Generic;

    public static class CollectionExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item)) yield return item;
            }
        }
        
        public static IEnumerable<T> GetAllItems<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection) yield return item;
        }
    }
}