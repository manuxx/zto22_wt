using System;
using System.Collections.Generic;
using System.Linq;
using Training.DomainClasses;

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

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                {
                    yield return pet;
                }
            }
        }

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.Contains(newPet))
                return;

            _petsInTheStore.Add(newPet);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return GetMatchingPets(p => p.yearOfBirth > 2011 || p.species == Species.Rabbit);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return GetMatchingPets(p => p.species == Species.Dog && p.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return GetMatchingPets(p => p.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return GetMatchingPets(p => p.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return GetMatchingPets(p => p.species == Species.Cat || p.species == Species.Dog);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return GetMatchingPets(p => p.species == Species.Dog && p.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return GetMatchingPets(p => p.sex == Sex.Female);
        }

        private IEnumerable<Pet> GetMatchingPets(Func<Pet, bool> condition)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (condition(pet))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllMice()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Mouse)
                {
                    yield return pet;
                }
            }
        }
    }
}