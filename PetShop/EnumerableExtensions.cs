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

    public static IEnumerable<TItem> GetMatchingItem<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        return items.GetMatchingItem(new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> GetMatchingItem<TItem>(this IEnumerable<TItem> items, ICriteria<TItem> criteria)
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

internal class AnonymousCriteria<TItem> : ICriteria<TItem>
{
    private readonly Predicate<TItem> _condition;

    public AnonymousCriteria(Predicate<TItem> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _condition(item);
    }
}