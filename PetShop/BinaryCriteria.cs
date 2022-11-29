namespace Training.DomainClasses
{
    public class BinaryCriteria<TItem> : ICriteria<TItem>
    {

        public bool IsSatisfiedBy(TItem item)
        {
            return false;
        }
    }
}