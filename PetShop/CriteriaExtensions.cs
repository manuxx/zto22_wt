using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

namespace PetShop
{
    public static class CriteriaExtensions
    {
        public static Conjunction<Pet> And(this ICriteria<Pet> left, ICriteria<Pet> right)
        {
            return new Conjunction<Pet>(left, right);
        }

        public static Alternative<Pet> Or(this ICriteria<Pet> left, ICriteria<Pet> right)
        {
            return new Alternative<Pet>(left,right);
        }
    }
}
