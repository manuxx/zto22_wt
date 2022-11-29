<<<<<<< HEAD
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
=======
namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TItem> : ICriteria<TItem>
    {
        protected ICriteria<TItem> _criteria1;
        protected ICriteria<TItem> _criteria2;

        public BinaryCriteria(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
>>>>>>> 9f1f1e1392fd8843b96ab23f32e30298b72e4f95
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }
}