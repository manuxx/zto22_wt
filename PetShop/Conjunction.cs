namespace Training.DomainClasses
{
    public class Conjunction<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem>[] _criterias;

        public Conjunction(params ICriteria<TItem>[] criterias)
        {
            _criterias = criterias;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            foreach (var criteria in _criterias)
            {
                if (!criteria.IsSatisfiedBy(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}