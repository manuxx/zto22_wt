using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var sortedPets = new List<Pet>(_petsInTheStore);
            for (int i = 0; i < sortedPets.Count - 1; i++)
            {
                for (var j = i; j < sortedPets.Count; j++)
                {
                    if (sortedPets[i].name.CompareTo(sortedPets[j].name) > 0)
                    {
                        (sortedPets[i], sortedPets[j]) = (sortedPets[j], sortedPets[i]);
                    }
                }
            }
            return sortedPets;
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

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return result;
        }
    }
}