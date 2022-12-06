using System;

namespace Training.Specificaton
{
    internal static class FilteringEntryPointsExtensions
    {
        public static ICriteria<TItem> IsEqualTo<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty propertyValue)
        {
            return new AnonymousCriteria<TItem>(item => filteringEntryPoint._selector(item).Equals(propertyValue));
        }

        public static ICriteria<TItem> IsGreaterThan<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty propertyValue) where TProperty : IComparable<TProperty>
        {
            return new AnonymousCriteria<TItem>(item => filteringEntryPoint._selector(item).CompareTo(propertyValue) > 0);
        }
    }
}