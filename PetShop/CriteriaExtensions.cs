using Training.DomainClasses;

public static class CriteriaExtensions
{
    public static BinaryCriteria<TItem> And<TItem>(this ICriteria<TItem> leftCriteria, ICriteria<TItem> rightCriteria)
    {
        return new Conjunction<TItem>(leftCriteria,rightCriteria );
    }

    public static Alternative<TItem> Or<TItem>(this ICriteria<TItem> leftCriteria, ICriteria<TItem> rightCriteria)
    {
        return new Alternative<TItem>(leftCriteria, rightCriteria);
    }
    
    public static Negation<TItem> Not<TItem>(this ICriteria<TItem> criteria)
    {
        return new Negation<TItem>(criteria);
    }
}