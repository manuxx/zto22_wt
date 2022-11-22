using System;
using System.Collections.Generic;
using PetShop;
using Training.DomainClasses;

public static class EnumerableExtensions
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
        return items.GetMatching<TItem>(new AnonymousCriteria<TItem>(condition));
    }
    public static IEnumerable<TItem> GetMatching<TItem>(this IList<TItem> items, ICriteria<TItem> criteria)
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