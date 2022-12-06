using System;

namespace Training.Specificaton
{
    public static class FilteringEntryPointExtensions
    {
        public static ICriteria<TItem> EqualTo<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty propertyValue)
        {
            return new AnonymousCriteria<TItem>(item=> filteringEntryPoint._selector(item).Equals(propertyValue));
        }

        public static ICriteria<TItem> GreaterThan<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty propertyValue) where TProperty : IComparable<TProperty>
        {
            return new AnonymousCriteria<TItem>(item => filteringEntryPoint._selector(item).CompareTo(propertyValue) > 0);
        }
    }
}