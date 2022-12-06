using System;
using Training.Specificaton;

static internal class FilteringEntryPointExtensions
{
    public static ICriteria<TItem> EqualTo<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty value)
    {
        return new AnonymousCriteria<TItem>(item=> filteringEntryPoint._selector(item).Equals(value));
    }

    public static ICriteria<TItem> IsGreaterThan<TProperty, TItem>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty value)
        where TProperty : IComparable<TProperty>
    {
        return new AnonymousCriteria<TItem>(item => filteringEntryPoint._selector(item).CompareTo(value)>0);
    }
}