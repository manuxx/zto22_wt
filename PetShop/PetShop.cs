using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using PetShop;

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
            return _petsInTheStore.GetMatching(Pet.IsASpeciesOf(Species.Cat).Or(Pet.IsASpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.GetMatching(Pet.IsNotASpeciesOf(Species.Mouse));
        }


        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.GetMatching(Pet.IsASpeciesOf(Species.Dog).And(Pet.IsBornAfter(2010)));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.GetMatching(Pet.IsASpeciesOf(Species.Dog).And(Pet.IsMale()));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.GetMatching(Pet.IsASpeciesOf(Species.Rabbit).Or(Pet.IsBornAfter(2011)));
        }
    }
}