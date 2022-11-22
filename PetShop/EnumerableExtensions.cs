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
        return pets.GetMatchingPets(new AnonymousCriteria<TElement>(condition));
    }

    public static IEnumerable<TElement> GetMatchingPets<TElement>(this IList<TElement> pets, Criteria<TElement> criteria)
    {
        foreach (var pet in pets)
        {
            if (criteria.IsSatisfiedBy(pet))
            {
                yield return pet;
            }
        }
    }
}