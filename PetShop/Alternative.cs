namespace Training.DomainClasses
{
    public class Alternative<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem>[] _criterias;

        public Alternative(params ICriteria<TItem>[] criterias)
        {
            _criterias = criterias;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            foreach (var criteria in _criterias)
            {
                if (criteria.IsSatisfiedBy(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}