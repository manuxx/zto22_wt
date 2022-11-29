namespace Training.DomainClasses
{
    public partial class PetShop
    {
        private class Alternative<TItem> : ICriteria<TItem>
        {
            private ICriteria<TItem>[] _criterias;

            public Alternative(params ICriteria<TItem>[] criterias)
            {
                this._criterias = criterias;
            }

            public bool IsSatisfiedBy(TItem item)
            {
                foreach (var criterion in _criterias)
                {
                    if (criterion.IsSatisfiedBy(item))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}