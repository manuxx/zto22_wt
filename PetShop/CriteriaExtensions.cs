namespace Training.DomainClasses
{
    static class CriteriaExtensions
    {
        public static ICriteria<TItem> And<TItem>(this ICriteria<TItem> criteria, ICriteria<TItem> other)
        {
            return new Conjunction<TItem>(criteria, other);
        }
        
        public static ICriteria<TItem> Or<TItem>(this ICriteria<TItem> criteria, ICriteria<TItem> other)
        {
            return new Alternative<TItem>(criteria, other);
        }
    }
}