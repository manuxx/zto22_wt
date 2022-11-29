namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<T> : ICriteria<T>
    {
        protected ICriteria<T> _criteria1;
        protected ICriteria<T> _criteria2;

        public BinaryCriteria(ICriteria<T> criteria1, ICriteria<T> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public abstract bool IsSatisfiedBy(T item);
    }
}