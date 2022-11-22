using System;
using System.Collections.Generic;
using System.Diagnostics;
using PetShop;
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
        return items.GetMatching(new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> GetMatching<TItem>(this IEnumerable<TItem> items, ICriteria<TItem> criteria)
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

public class AnonymousCriteria<TItem> : ICriteria<TItem>
{
    private readonly Predicate<TItem> _condition;
    public AnonymousCriteria(Predicate<TItem> condition)
    {
        this._condition = condition;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _condition(item);
    }
}