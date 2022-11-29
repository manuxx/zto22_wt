using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop
{
    public class Criterias
    {
    }
}

namespace Training.DomainClasses
{
    public class Alternative<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _criteria1;
        private readonly ICriteria<TItem> _criteria2;

        public Alternative(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
        }
    }

    public class Negation<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _isASpeciesOf;

        public Negation(ICriteria<TItem> isASpeciesOf)
        {
            _isASpeciesOf = isASpeciesOf;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_isASpeciesOf.IsSatisfiedBy(item);
        }
    }

    public class Conjuction<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _criterium1;
        private readonly ICriteria<TItem> _criteirum2;

        public Conjuction(ICriteria<TItem> criterium1, ICriteria<TItem> criteirum2)
        {
            _criterium1 = criterium1;
            _criteirum2 = criteirum2;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _criteirum2.IsSatisfiedBy(item) && _criterium1.IsSatisfiedBy(item);
        }
    }
}