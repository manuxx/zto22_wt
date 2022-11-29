using Training.DomainClasses;

public interface ICriteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}

public static class CriteriaExtensions
{
    public static BinaryCriteria<TItem> And<TItem>(this ICriteria<TItem> criteria, ICriteria<TItem> criteria2)
    {
        return new Conjunction<TItem>(criteria, criteria2);
    }

    public static BinaryCriteria<TItem> Or<TItem>(this ICriteria<TItem> criteria, ICriteria<TItem> criteria2)
    {
        return new Alternative<TItem>(criteria, criteria2);
    }

    public static ICriteria<TItem> Not<TItem>(ICriteria<TItem> criteria)
    {
        return new Negation<TItem>(criteria);
    }
}
