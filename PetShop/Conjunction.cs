namespace Training.DomainClasses
{
    public class Conjunction<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem>[] _criteriats;


        public Conjunction(params ICriteria<TItem>[] criterias)
        {
            _criteriats = criterias;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            foreach (var criteria in _criteriats)
            {
                if (!criteria.IsSatisfiedBy(item))
                    return false;
            }

            return true;
        }
    }
}