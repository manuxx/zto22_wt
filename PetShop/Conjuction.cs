namespace Training.DomainClasses
{
    public class Conjuction<TItem> : BinaryCriteria<TItem>
    {

        public Conjuction(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2) : base(criteria1, criteria2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
        }
    }
}