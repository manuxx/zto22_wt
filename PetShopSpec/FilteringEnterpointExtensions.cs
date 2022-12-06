using System;

namespace Training.Specificaton
{
    static class CriteriaBuilderExtensions
    {
        public static ICriteria<TItem> IsEqualTo<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty value)
        {
            return new AnonymousCriteria<TItem>(item => criteriaBuilder._selector(item).Equals(value));
        }

        public static ICriteria<TItem> IsGreaterThan<TProperty, TItem>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty value)
            where TProperty : IComparable<TProperty>
        {
            return new AnonymousCriteria<TItem>(item => criteriaBuilder._selector(item).CompareTo(value) > 0);
        }
    }
}