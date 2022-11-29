namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TItem> : ICriteria<TItem>
    {
        protected ICriteria<TItem> _criteriaA;
        protected ICriteria<TItem> _criteriaB;

        public BinaryCriteria(ICriteria<TItem> criteriaA, ICriteria<TItem> criteriaB)
        {
            _criteriaA = criteriaA;
            _criteriaB = criteriaB;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }
}