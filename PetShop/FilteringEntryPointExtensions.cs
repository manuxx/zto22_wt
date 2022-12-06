using System;
using Training.DomainClasses;

namespace Training.Specificaton
{
    public static class FilteringEntryPointExtensions
    {
        public static ICriteria<TItem> EqualTo<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty propertyValue)
        {
            var resultCriteria = new AnonymousCriteria<TItem>(item => filteringEntryPoint._selector(item).Equals(propertyValue));
            if (filteringEntryPoint._negationActive)
            {
                return new Negation<TItem>(resultCriteria);
            }
            else
            {

                return resultCriteria;
            }
        }

        public static ICriteria<TItem> GreaterThan<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty propertyValue) where TProperty : IComparable<TProperty>
        {
            return new AnonymousCriteria<TItem>(item => 
                filteringEntryPoint._negationActive ? filteringEntryPoint._selector(item).CompareTo(propertyValue) < 0: filteringEntryPoint._selector(item).CompareTo(propertyValue) > 0);
        }

        public static FilteringEntryPoint<TItem, TProperty> Not<TItem, TProperty>(
            this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint)
        {
            var newNegationActive = !filteringEntryPoint._negationActive;
            return new FilteringEntryPoint<TItem, TProperty>(filteringEntryPoint._selector, newNegationActive);

        }
    }
}