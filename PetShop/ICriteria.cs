namespace PetShop
{
    public interface ICriteria<TItem>
    {
        bool IsSatisfiedBy(TItem item);
    }
}