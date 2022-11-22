using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ListExtension
    {
        public static IEnumerable<Pet> GetMatchingPets(Func<Pet, bool> condition, IList<Pet> petsInTheStore)
        {
            foreach (var pet in petsInTheStore)
            {
                if (condition(pet))
                {
                    yield return pet;
                }
            }
        }
    }
}