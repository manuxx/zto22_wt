namespace Training.DomainClasses
{
    public class Negation<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _isASpeciesOf;

        public Negation(ICriteria<TItem> isASpeciesOf)
        {
            _isASpeciesOf = isASpeciesOf;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_isASpeciesOf.IsSatisfiedBy(item);
        }
    }
}