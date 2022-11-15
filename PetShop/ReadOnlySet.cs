using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public partial class PetShop
    {
        public class ReadOnlySet<TItem> : IEnumerable<TItem>
        {
            private readonly IEnumerable<TItem> _set;

            public ReadOnlySet(IEnumerable<TItem> set)
            {
                _set = set;
            }

            public IEnumerator<TItem> GetEnumerator()
            {
                return _set.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}