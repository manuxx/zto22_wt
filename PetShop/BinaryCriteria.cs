
﻿namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TItem> : ICriteria<TItem>
    {
        public ICriteria<Pet> _c1;
        public ICriteria<Pet> _c2;

        public BinaryCriteria(ICriteria<Pet> c1, ICriteria<Pet> c2)
        {
            _c1 = c1;
            _c2 = c2;

        }

        public abstract bool IsSatisfiedBy(TItem item);
    }
}