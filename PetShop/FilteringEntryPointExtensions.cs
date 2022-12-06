using System;
using System.Collections.Generic;
using System.Threading;
using PetShop;

public static class FilteringEntryPointExtensions
{
    public static ICriteria<TItem> EqualTo<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty property)
    {
        return new AnonymousCriteria<TItem>(item => filteringEntryPoint._selector(item).Equals(property) != filteringEntryPoint._negationActive);
    }

    public static ICriteria<TItem> GreaterThan<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty property) where TProperty:IComparable<TProperty>
    {
        return new AnonymousCriteria<TItem>(item => filteringEntryPoint._negationActive ? filteringEntryPoint._selector(item).CompareTo(property) <= 0 : filteringEntryPoint._selector(item).CompareTo(property) > 0);
    }


}