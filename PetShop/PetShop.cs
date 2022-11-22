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
            return ListExtension.GetMatchingPets(pet => pet.species == Species.Cat, _petsInTheStore);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return ListExtension.GetMatchingPets(pet => pet.species == Species.Mouse, _petsInTheStore);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return ListExtension.GetMatchingPets(pet => pet.sex == Sex.Female, _petsInTheStore);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return ListExtension.GetMatchingPets(pet => pet.species==Species.Cat || pet.species == Species.Dog, _petsInTheStore);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return ListExtension.GetMatchingPets(pet => pet.species != Species.Mouse, _petsInTheStore);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return ListExtension.GetMatchingPets(pet => pet.yearOfBirth > 2010, _petsInTheStore);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return ListExtension.GetMatchingPets(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010, _petsInTheStore);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return ListExtension.GetMatchingPets(pet => pet.sex == Sex.Male && pet.species == Species.Dog, _petsInTheStore);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return ListExtension.GetMatchingPets(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit, _petsInTheStore);
        }
    }
}