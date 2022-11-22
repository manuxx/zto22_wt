namespace Training.DomainClasses
{
    public class BornAfterCriteria : Criteria<Pet>
    {
        private int _year;
        public BornAfterCriteria(int year)
        {
            _year = year;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.yearOfBirth > _year;
        }
    }
}