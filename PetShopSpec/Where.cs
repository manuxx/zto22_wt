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

        public FilteringEntrypoint(Func<TItem, TProp> selector)
        {
            _selector = selector;
        }
    }
}

static internal class FilteringEntrypointExtensions
{
    public static ICriteria<TItem> IsEqualTo<TItem, TProp>(this FilteringEntrypoint<TItem, TProp> filteringEntrypoint, TProp property)
    {
        return new AnonymousCriteria<TItem>(subject => filteringEntrypoint._selector(subject).Equals(property));
    }

    public static ICriteria<TItem> IsGreaterThan<TItem, TProp>(this FilteringEntrypoint<TItem, TProp> filteringEntrypoint, TProp comparedTo) where TProp : IComparable<TProp>
    {
        return new AnonymousCriteria<TItem>(subject => filteringEntrypoint._selector(subject).CompareTo(comparedTo) > 0);
    }
}