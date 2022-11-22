namespace Training.DomainClasses
{
    public class BornAfterCriteria : ICriteria<Pet>
    {
        private int Year;
        public BornAfterCriteria(int i)
        {
            Year = i;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.yearOfBirth > Year;
        }
    }
}