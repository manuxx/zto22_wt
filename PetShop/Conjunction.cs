namespace Training.DomainClasses
{
    public class Conjunction<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _firstCriteria;
        private readonly ICriteria<TItem> _secondCriteria;

        public Conjunction(ICriteria<TItem> firstCriteria, ICriteria<TItem> secondCriteria)
        {
            _firstCriteria = firstCriteria;
            _secondCriteria = secondCriteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _firstCriteria.IsSatisfiedBy(item) && _secondCriteria.IsSatisfiedBy(item);
        }
    }
}