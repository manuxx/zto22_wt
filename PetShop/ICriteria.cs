using Training.DomainClasses;

public interface ICriteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}

static class CriteriaExtensions
{
    public static ICriteria<T> And<T>(this ICriteria<T> criteria1, ICriteria<T> criteria2)
    {
        return new Conjunction<T>(criteria1, criteria2);
    }

    public static ICriteria<T> Or<T>(this ICriteria<T> criteria1, ICriteria<T> criteria2)
    {
        return new Alternative<T>(criteria1, criteria2);
    }
}