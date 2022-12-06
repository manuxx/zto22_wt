using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

namespace PetShop
{
    public class Where<TItem, TField>
    {
        static CriteriaBuilder<TItem, TField> Has(Func<TItem, TField> selector)
        {
            return new CriteriaBuilder<TItem, TField>(selector);
        }
    }

    internal class CriteriaBuilder<TItem, TField>
    {
        private readonly Func<TItem, TField> _selector;

        public CriteriaBuilder(Func<TItem, TField> selector)
        {
            _selector = selector;
        }

        public ICriteria<Pet> IsEqualTo(Species species)
        {
            return new Pet.SpeciesCriteria(species);
        }
    }
}
