using System;
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
            foreach (var pet in _petsInTheStore)
            {
                yield return pet;
            }
        }

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.Contains(newPet))
                return;

            _petsInTheStore.Add(newPet);
        }

        public IEnumerable<Pet> AllCats()
        {
            return PetsWhere(p => p.species == Species.Cat);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return PetsWhere(p => p.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return PetsWhere(p => p.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return PetsWhere(p => p.species == Species.Cat || p.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return PetsWhere(p => p.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return PetsWhere(p => p.yearOfBirth> 2010);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return PetsWhere(p => p.yearOfBirth > 2011 || p.species == Species.Rabbit);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return PetsWhere(p => p.sex == Sex.Male && p.species == Species.Dog);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return PetsWhere(p => p.species == Species.Dog && p.yearOfBirth > 2010);
        }
        
        private IEnumerable<Pet> PetsWhere(Func<Pet, bool> predicate)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (predicate(pet))
                {
                    yield return pet;
                }
            }
        }
    }
}