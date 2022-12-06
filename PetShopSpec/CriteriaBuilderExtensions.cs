using System;
using Training.Specificaton;

static internal class CriteriaBuilderExtensions
{
    public static ICriteria<TItem> IsEqualTo<TItem, TProperty>(CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty value)
    {
        return new AnonymousCriteria<TItem>(item=> criteriaBuilder._selector(item).Equals(value));
    }

    public static ICriteria<TItem> IsGreaterThan<TProperty, TItem>(CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty value)
        where TProperty : IComparable<TProperty>
    {
        return new AnonymousCriteria<TItem>(item => criteriaBuilder._selector(item).CompareTo(value)>0);
    }
}