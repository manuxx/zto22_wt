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
            return _petsInTheStore.GetMatching((pet => pet.species==Species.Cat || pet.species == Species.Dog));
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
            return _petsInTheStore.GetMatching((pet => pet.sex == Sex.Male && pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.GetMatching((pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit));
        }
    }

    public class Conjunction : ICriteria<Pet>
    {
        public Conjunction(ICriteria<Pet> isASpeciesOf, ICriteria<Pet> isMale)
        {
            throw new NotImplementedException();
        }

        public bool IsSatisfiedBy(Pet item)
        {
            throw new NotImplementedException();
        }
    }

    public class Disjunction : ICriteria<Pet>
    {
        public Disjunction(ICriteria<Pet> isASpeciesOf, ICriteria<Pet> isBornAfter)
        {
            throw new NotImplementedException();
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return 
        }
    }

}