using System;
using Training.Specificaton;

public static class CriteriaBuilderExtensions
{
    public static ICriteria<TItem> IsEqualTo<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty value)
    {
        return new AnonymousCriteria<TItem>(item=> filteringEntryPoint._selector(item).Equals(value));
    }

    public static ICriteria<TItem> IsGreaterThan<TProperty, TItem>
        (this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty value)
        where TProperty : IComparable<TProperty>
    {
        return new AnonymousCriteria<TItem>(item => filteringEntryPoint._selector(item).CompareTo(value) > 0);
    }
}