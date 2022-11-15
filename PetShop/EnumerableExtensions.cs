using System;
using System.Collections.Generic;
using Training.DomainClasses;

static internal class EnumerableExtensions
{
    public static IEnumerable<TElement> OneAtATime<TElement>(this IEnumerable<TElement> items)
    {
        foreach (var element in items)
        {
            yield return element;
        }
    }
}