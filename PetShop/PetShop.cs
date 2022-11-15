using System;
using System.Buffers;
using System.Collections;
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
            return GetMatchingPets(pet => pet.species == Species.Cat);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return GetMatchingPets(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return GetMatchingPets(pet => pet.sex == Sex.Female);
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

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return GetMatchingPets(pet => pet.species==Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return GetMatchingPets(pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return GetMatchingPets(pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return GetMatchingPets(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return GetMatchingPets(pet => pet.sex == Sex.Male && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return GetMatchingPets(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
        }
    }

    public class ReadOnlySet<IItem> : IEnumerable<IItem>
    {
        private readonly IEnumerable<IItem> _pets;

        public ReadOnlySet(IEnumerable<IItem> pets)
        {
            _pets = pets;
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            foreach (var pet in _pets)
            {
                yield return pet;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var pet in _pets)
            {
                yield return pet;
            }
        }
    }
}