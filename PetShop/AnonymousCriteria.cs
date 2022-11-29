using System;
using System.Threading;
using Training.DomainClasses;

internal class AnonymousCriteria<TItem> : ICriteria<TItem>
{
    private readonly Predicate<TItem> _condition;

    public AnonymousCriteria(Predicate<TItem> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _condition(item);
    }
}