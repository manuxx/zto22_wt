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

    public static IEnumerable<TItem> GetMatching<TItem>(this IList<TItem> items, Predicate<TItem> condition)
    {
        return items.GetMatching(new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<Item> GetMatching<Item>(this IList<Item> items, Criteria<Item> criteria)
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