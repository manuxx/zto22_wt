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

    public static IEnumerable<TItem> GetMatching<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        foreach (var item in items)
        {
            if (condition(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<TItem> GetMatching<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
            {
                yield return item;
            }
        }
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy<TItem>(TItem item);
}