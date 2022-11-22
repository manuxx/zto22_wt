using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Training.DomainClasses;

internal static class EnumerableExtensions
{
    public static IEnumerable<TElement> OneAtATime<TElement>(this IEnumerable<TElement> items)
    {
        foreach (var element in items)
        {
            yield return element;
        }
    }

    public static IEnumerable<TElement> GetMatchingElements<TElement>(this IEnumerable<TElement> items,
        Predicate<TElement> condition)
    {
        return items.GetMatchingElements(new AnonymousCriteria<TElement>(condition));
    }

    public static IEnumerable<TElement> GetMatchingElements<TElement>(this IEnumerable<TElement> items, 
        ICriteria<TElement> criteria)
    {
        foreach (var element in items)
        {
            if (criteria.IsSatisfiedBy(element))
            {
                yield return element;
            }
        }
    }
}

public class AnonymousCriteria<TElement> : ICriteria<TElement>
{
    private readonly Predicate<TElement> _condition;

    public AnonymousCriteria(Predicate<TElement> condition)
    {
        this._condition = condition;
    }

    public bool IsSatisfiedBy(TElement item)
    {
        return _condition(item);
    }
}

public interface ICriteria<TElement>
{
    bool IsSatisfiedBy(TElement item);
}