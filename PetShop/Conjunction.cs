using System.Reflection.Metadata.Ecma335;

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
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }

    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {
        public Conjunction(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2) : base(criteria1, criteria2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _criteria1.IsSatisfiedBy(item) &&
                   _criteria2.IsSatisfiedBy(item);
        }
    }
}