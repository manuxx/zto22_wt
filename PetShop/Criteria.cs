public interface Criteria<TElement>
{
    bool IsSatisfiedBy(TElement pet);
}