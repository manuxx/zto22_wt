using System;

public static class FilteringEntryPointExtensions
{
    public static ICriteria<TItem> EqualTo<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty value)
    {
        return filteringEntryPoint._negation 
            ? new AnonymousCriteria<TItem>(item => !filteringEntryPoint._selector(item).Equals(value)) 
            : new AnonymousCriteria<TItem>(item => filteringEntryPoint._selector(item).Equals(value));
    }

    public static ICriteria<TItem> GreaterThan<TProperty, TItem>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty value)
        where TProperty : IComparable<TProperty>
    {
        return filteringEntryPoint._negation
        ? new AnonymousCriteria<TItem>(item => filteringEntryPoint._selector(item).CompareTo(value) <= 0)
        : new AnonymousCriteria<TItem>(item => filteringEntryPoint._selector(item).CompareTo(value) > 0);
    }
    
}