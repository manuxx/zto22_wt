namespace Training.DomainClasses
{
    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {
        public Conjunction(ICriteria<TItem> criteriaA, ICriteria<TItem> criteriaB) : base(criteriaA, criteriaB)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _criteriaA.IsSatisfiedBy(item) && _criteriaB.IsSatisfiedBy(item);
        }
    }
}