using System;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public bool Equals(Pet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return name == other.name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Pet) obj);
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return $"Pet: {this.name}";
        }


        public static bool operator ==(Pet left, Pet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !Equals(left, right);
        }

        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static ICriteria<Pet> IsASpeciesOf(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Predicate<Pet> IsFemale()
        {
            return pet => pet.sex == Sex.Female;
        }

        // public static ICriteria<Pet> IsNotASpeciesOf(Species species)
        // {
        //     return new Negation<Pet>(IsASpeciesOf(species));
        // }

        public static ICriteria<Pet> IsBornAfter(int year)
        {
            return new BornAfterCriteria(year);
        }

        public static ICriteria<Pet> IsASexOf(Sex sex)
        {
            return new SexCriteria(sex);
        }
    }

    public class BornAfterCriteria : ICriteria<Pet>
    {
        private readonly int _year;

        public BornAfterCriteria(int year)
        {
            _year = year;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.yearOfBirth > _year;
        }
    }

    public class SpeciesCriteria : ICriteria<Pet>
    {
        private readonly Species _species;

        public SpeciesCriteria(Species species)
        {
            this._species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.species.Equals(_species);
        }
    }

    public class SexCriteria : ICriteria<Pet>
    {
        private readonly Sex _sex;

        public SexCriteria(Sex sex)
        {
            this._sex = sex;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.sex.Equals(_sex);
        }
    }

    public class Negation<T> : ICriteria<T>
    {
        private readonly ICriteria<T> _criteria;

        public Negation(ICriteria<T> criteria)
        {
            this._criteria = criteria;
        }

        public bool IsSatisfiedBy(T item)
        {
            return !_criteria.IsSatisfiedBy(item);
        }
    }
}