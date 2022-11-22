using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

    static class GetMatchingPetsExtensions
    {
        public static IEnumerable<TItem> GetMatchingPets<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
        {
            foreach (var item in items)
            {
                if (condition(item))
                {
                    yield return item;
                }
            }
        }
    }

