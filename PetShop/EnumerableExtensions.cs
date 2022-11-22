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

public class AnonymousCriteria<T>: ICriteria<T>
{
    private Predicate<T> _condition;
    public AnonymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public interface ICriteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}