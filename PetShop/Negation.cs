namespace Training.DomainClasses
{
    public class Negation<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _isSpeciesOf;
        public Negation(ICriteria<TItem> isSpeciesOf)
        {
            _isSpeciesOf = isSpeciesOf;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_isSpeciesOf.IsSatisfiedBy(item);
        }
    }
}