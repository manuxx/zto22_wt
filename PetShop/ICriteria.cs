namespace PetShop
{
    public interface ICriteria<TItem>
    {
        public bool IsSatisfiedBy(TItem item);
    }
}