using System;

namespace Training.Specificaton
{
    static internal class CriteriaBuilderExtensions
    {
        public static ICriteria<TItem> IsEqualTo<TItem, TProperty>(CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty propertyValue)
        {
            return new AnonymousCriteria<TItem>(item=> criteriaBuilder._selector(item).Equals(propertyValue));
        }

        public static ICriteria<TItem> IsGreaterThan<TItem, TProperty>(CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty propertyValue) where TProperty : IComparable<TProperty>
        {
            return new AnonymousCriteria<TItem>(item => criteriaBuilder._selector(item).CompareTo(propertyValue) > 0);
        }
    }
}