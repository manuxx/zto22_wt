namespace Training.DomainClasses
{
    public partial class PetShop
    {
        private class Conjunction<TItem> : ICriteria<TItem>
        {
            private ICriteria<TItem>[] _criterias;

            public Conjunction(params ICriteria<TItem>[] criterias)
            {
                this._criterias = criterias;
            }

            public bool IsSatisfiedBy(TItem item)
            {
                foreach(var criterion in _criterias)
                {
                    if (!criterion.IsSatisfiedBy(item))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}