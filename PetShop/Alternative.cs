namespace Training.DomainClasses
{
    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(ICriteria<TItem> criteriaA, ICriteria<TItem> criteriaB) : base(criteriaA, criteriaB)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _criteriaA.IsSatisfiedBy(item) || _criteriaB.IsSatisfiedBy(item);
        }
    }
}