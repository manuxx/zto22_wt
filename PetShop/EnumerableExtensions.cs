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

    public static IEnumerable<TElement> GetMatchingPets<TElement>(this IList<TElement> pets, Predicate<TElement> condition)
    {
        foreach (var pet in pets)
        {
            if (condition(pet))
            {
                yield return pet;
            }
        }
    }
}