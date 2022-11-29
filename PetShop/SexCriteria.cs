namespace Training.DomainClasses
{
    public class SexCriteria : ICriteria<Pet>
    {
        private Sex sex;

        public SexCriteria(Sex sex)
        {
            this.sex = sex;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return (item.sex == this.sex);
        }
    }
}