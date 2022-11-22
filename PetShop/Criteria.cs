using System;
using PetShop;
using Training.DomainClasses;

public class AnonymousCriteria<T>:ICriteria<T>
{
    private Predicate<T> _condition;
    public AnonymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
    public class NotASpeciesCriteria : ICriteria<Pet>
    {
        private readonly Species _species;
        public NotASpeciesCriteria(Species species)
        {
            this._species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return (item.species == _species);
        }
    }

    public class BornAfterCriteria : ICriteria<Pet>
    {
        private readonly int _year;
        public BornAfterCriteria(int year)
        {
            this._year = year;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return (item.yearOfBirth > _year);
        }
    }
}