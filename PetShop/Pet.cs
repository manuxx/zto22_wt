using System;

namespace Training.DomainClasses
{
    public class Pet 
    {
        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            var other = (Pet)obj;
            return this.name == other.name && this.yearOfBirth == other.yearOfBirth && this.price == other.price && this.species == other.species;
        }
    }
}