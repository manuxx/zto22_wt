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

    public static IEnumerable<Pet> GetMatchingPets(this IList<Pet> petsInTheStore, Func<Pet, bool> condition)
    {
        foreach (var pet in petsInTheStore)
        {
            if (condition(pet))
            {
                yield return pet;
            }
        }
    }
}