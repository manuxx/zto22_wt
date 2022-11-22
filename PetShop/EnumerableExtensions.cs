using System;
using System.Collections.Generic;
using Training.DomainClasses;

static class EnumerableExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<T> GetMatchingObjects<T>(this IEnumerable<T> items, Func<T, bool> condition)
    {
        foreach (var item in items)
        {
            if (condition(item))
            {
                yield return item;
            }
        }
    }
}