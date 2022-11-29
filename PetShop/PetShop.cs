using System;
using System.Buffers;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnlySet<Pet>(_petsInTheStore);
        }

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.Contains(newPet))
                return;

            _petsInTheStore.Add(newPet);
        }

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.GetMatching(Pet.IsASpeciesOf(Species.Cat));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.GetMatching(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.GetMatching(Pet.IsASpeciesOf(Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.GetMatching(Pet.IsFemale());
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.GetMatching(new Alternative<Pet>(Pet.IsASpeciesOf(Species.Dog), Pet.IsASpeciesOf(Species.Cat)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.GetMatching(Pet.IsNotASpeciesOf(Species.Mouse));
        }


        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.GetMatching((pet => pet.species == Species.Dog && pet.yearOfBirth > 2010));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.GetMatching(new Conjunction<Pet>(Pet.IsASpeciesOf(Species.Dog), Pet.IsMale()));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.GetMatching((pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit));
        }

        private class Conjunction<TItem> : ICriteria<TItem>
        {
            private ICriteria<TItem> criteria1;
            private ICriteria<TItem> criteria2;

            public Conjunction(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
            {
                this.criteria1 = criteria1;
                this.criteria2 = criteria2;
            }

            public bool IsSatisfiedBy(TItem item)
            {
                return criteria1.IsSatisfiedBy(item) && criteria2.IsSatisfiedBy(item);
            }
        }

        private class Alternative<TItem> : ICriteria<TItem>
        {
            private ICriteria<TItem> criteria1;
            private ICriteria<TItem> criteria2;

            public Alternative(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
            {
                this.criteria1 = criteria1;
                this.criteria2 = criteria2;
            }

            public bool IsSatisfiedBy(TItem item)
            {
                return criteria1.IsSatisfiedBy(item) || criteria2.IsSatisfiedBy(item);
            }
        }
    }
}