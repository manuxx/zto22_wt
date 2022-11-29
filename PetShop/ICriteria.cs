using System;
using Training.DomainClasses;

public interface ICriteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}

public static class CriteriaExtensions
{
    public static BinaryCriteria<TItem> And<TItem>(this ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
    {
        return new Conjunction<TItem>(criteria1, criteria2);
    }

    public static BinaryCriteria<TItem> Or<TItem>(this ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
    {
        return new Alternative<TItem>(criteria1, criteria2);
    }
}