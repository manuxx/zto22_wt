using System;

namespace Training.Specificaton
{
    static class FilteringEnterpointExtensions
    {
        public static ICriteria<TItem> IsEqualTo<TItem, TProperty>(this FilteringEnterpoint<TItem, TProperty> filteringEnterpoint, TProperty value)
        {
            return new AnonymousCriteria<TItem>(item =>
            {
                if(filteringEnterpoint._negationActive)
                    return !filteringEnterpoint._selector(item).Equals(value);
                else
                    return filteringEnterpoint._selector(item).Equals(value);
                
            });
        }

        public static ICriteria<TItem> IsGreaterThan<TProperty, TItem>(this FilteringEnterpoint<TItem, TProperty> filteringEnterpoint, TProperty value)
            where TProperty : IComparable<TProperty>
        {
            return new AnonymousCriteria<TItem>(item => filteringEnterpoint._selector(item).CompareTo(value) > 0);
        }
    }
}