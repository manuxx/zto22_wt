namespace Training.DomainClasses
{
    internal class SpeciesCriteria : ICriteria<Pet>
    {
        private Species species;

        public SpeciesCriteria(Species species)
        {
            this.species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return (item.species == this.species);
        }
    }
}