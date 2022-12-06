using System;
using Training.Specificaton;

static internal class CriteriaBuilderExtensions
{
    public static ICriteria<TItem> IsEqualTo<TItem, TProperty>(CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty property)
    {
        return new AnonymousCriteria<TItem>(item=> criteriaBuilder._selector(item).Equals(property));
    }

    public static ICriteria<TItem> IsGreaterThan<TItem, TProperty>(CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty property) where TProperty:IComparable<TProperty>
    {
        return new AnonymousCriteria<TItem>(item => criteriaBuilder._selector(item).CompareTo(property) > 0);
    }
}