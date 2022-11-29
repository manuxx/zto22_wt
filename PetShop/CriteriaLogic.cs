namespace Training.DomainClasses
{
    public class Negation<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _criteria;
        public Negation(ICriteria<TItem> criteria)
        {
            _criteria = criteria;
        }
        public bool IsSatisfiedBy(TItem item)
        {
            return !(_criteria.IsSatisfiedBy(item));
        }
    }

    public abstract class BinaryCriteria<TItem> : ICriteria<TItem>
    {
        protected ICriteria<TItem> _criteria1;
        protected ICriteria<TItem> _criteria2;

        public BinaryCriteria(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }

    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2) : base(criteria1, criteria2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return (_criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item));
        }
    }

    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {
        public Conjunction(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2) : base(criteria1, criteria2)
        {
        }
        public override bool IsSatisfiedBy(TItem item)
        {
            return (_criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item));
        }
    }
}