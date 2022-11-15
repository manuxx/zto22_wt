namespace Training.DomainClasses.Utils
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReadOnlySet<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _set;
        
        public ReadOnlySet(IEnumerable<T> collection)
        {
            _set =collection;
        }

        public bool Contains(T item)
        {
            return _set.Contains(item);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return _set.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }
}