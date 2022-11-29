namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TItem> : ICriteria<TItem>
    {
        protected ICriteria<TItem> _firstCriteria;
        protected ICriteria<TItem> _secondCriteria;

        public BinaryCriteria(ICriteria<TItem> firstCriteria, ICriteria<TItem> secondCriteria)
        {
            _firstCriteria = firstCriteria;
            _secondCriteria = secondCriteria;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }
}