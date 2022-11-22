using System;
using System.Buffers;
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
            return _petsInTheStore.GetMatchingElements(Pet.IsASpeciesOf(Species.Cat));
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
            return _petsInTheStore.GetMatchingElements(p => p.yearOfBirth > 2011 || p.species == Species.Rabbit);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.GetMatchingElements(p => p.species == Species.Dog && p.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.GetMatchingElements(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.GetMatchingElements(Pet.IsNotASpeciesOf(Species.Mouse));
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.GetMatchingElements(p => p.species == Species.Cat || p.species == Species.Dog);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.GetMatchingElements(p => p.species == Species.Dog && p.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.GetMatchingElements(Pet.HasSex(Sex.Female));
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.GetMatchingElements(Pet.IsASpeciesOf(Species.Mouse));
        }
    }
}