namespace Training.DomainClasses
{
    public class Conjunction : ICriteria<Pet>
    {
        private readonly ICriteria<Pet> _criteria1;
        private readonly ICriteria<Pet> _criteria2;
        public Conjunction(ICriteria<Pet> criteria1, ICriteria<Pet> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
        }
    }
    
}