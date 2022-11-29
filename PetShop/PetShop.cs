using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
            return _petsInTheStore.GetMatching(new Alternative(Pet.IsASpeciesOf(Species.Cat), Pet.IsASpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.GetMatching(Pet.IsNotASpeciesOf(Species.Mouse));
        }


        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.GetMatching(new Conjunction(Pet.IsASpeciesOf(Species.Dog), Pet.IsBornAfter(2010)));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.GetMatching(new Conjunction(Pet.IsASpeciesOf(Species.Dog), Pet.IsMale()));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.GetMatching(new Alternative(Pet.IsASpeciesOf(Species.Rabbit),
                Pet.IsBornAfter(2011)));
        }
    }

    public class Alternative : ICriteria<Pet>
    {
        private readonly ICriteria<Pet> _firstCriteria;
        private readonly ICriteria<Pet> _secondCriteria;

        public Alternative(ICriteria<Pet> firstCriteria, ICriteria<Pet> secondCriteria)
        {
            _firstCriteria = firstCriteria;
            _secondCriteria = secondCriteria;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return _firstCriteria.IsSatisfiedBy(item) || _secondCriteria.IsSatisfiedBy(item);
        }
    }

    public class Conjunction : ICriteria<Pet>
    {
        private readonly ICriteria<Pet> _firstCriteria;
        private readonly ICriteria<Pet> _secondCriteria;

        public Conjunction(ICriteria<Pet> firstCriteria, ICriteria<Pet> secondCriteria)
        {
            _firstCriteria = firstCriteria;
            _secondCriteria = secondCriteria;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return _firstCriteria.IsSatisfiedBy(item) && _secondCriteria.IsSatisfiedBy(item);
        }
    }
}