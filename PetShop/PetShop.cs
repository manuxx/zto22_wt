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
            return _petsInTheStore.GetMatching(new Alternative<Pet>(Pet.IsASpeciesOf(Species.Cat), Pet.IsASpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.GetMatching(new Negation<Pet>(Pet.IsASpeciesOf(Species.Mouse)));
        }


        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.GetMatching(new Conjunction<Pet>(Pet.IsASpeciesOf(Species.Dog), Pet.IsBornAfter(2010)));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.GetMatching(new Conjunction<Pet>(Pet.IsASpeciesOf(Species.Dog),Pet.IsMale() ));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.GetMatching(new Alternative<Pet>(Pet.IsBornAfter(2011), Pet.IsASpeciesOf(Species.Rabbit)));
        }
    }

    public class Alternative<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem>[] _criterias;

        public Alternative(ICriteria<TItem>[] criterias)
        {
            _criterias = criterias;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            foreach( var criteria in  _criterias)
            {
                if (criteria.IsSatisfiedBy(item))
                    return true;
            }

            return false;
        }
    }

    public class Conjunction<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem>[] _criterias;

        public Conjunction(ICriteria<TItem>[] criterias)
        {
            _criterias = criterias;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            foreach( var criteria in  _criterias)
            {
                if (!criteria.IsSatisfiedBy(item))
                    return false;
            }

            return true;
        }
    }

}