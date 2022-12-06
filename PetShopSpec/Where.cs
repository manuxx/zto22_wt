using System;
using Training.DomainClasses;
using Training.Specificaton;

namespace Training.Specificaton
{
    internal class Where<TItem>
    {
        public static FilteringEntrypoint<TItem, TProp> HasAn<TProp>(Func<TItem, TProp> selector)
        {
            return new FilteringEntrypoint<TItem, TProp>(selector);
        }
    }

    internal class FilteringEntrypoint<TItem, TProp>
    {
        public readonly Func<TItem, TProp> _selector;
        public bool negated;

        public FilteringEntrypoint(Func<TItem, TProp> selector)
        {
            _selector = selector;
            negated = false;
        }

        public FilteringEntrypoint<TItem, TProp> Not()
        {
            return new FilteringEntrypoint<TItem, TProp>(_selector) { negated = !this.negated };
        }
    }
}

static internal class FilteringEntrypointExtensions
{
    public static ICriteria<TItem> IsEqualTo<TItem, TProp>(this FilteringEntrypoint<TItem, TProp> filteringEntrypoint, TProp property)
    {
        if (!filteringEntrypoint.negated)
            return new AnonymousCriteria<TItem>(subject => filteringEntrypoint._selector(subject).Equals(property));
        return new AnonymousCriteria<TItem>(subject => !filteringEntrypoint._selector(subject).Equals(property));
    }

    public static ICriteria<TItem> IsGreaterThan<TItem, TProp>(this FilteringEntrypoint<TItem, TProp> filteringEntrypoint, TProp comparedTo) where TProp : IComparable<TProp>
    {
        if (!filteringEntrypoint.negated)
            return new AnonymousCriteria<TItem>(subject => filteringEntrypoint._selector(subject).CompareTo(comparedTo) > 0);
       return new AnonymousCriteria<TItem>(subject => filteringEntrypoint._selector(subject).CompareTo(comparedTo) <= 0);
    }
}