using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

namespace Training.DomainClasses
{
    internal class ReadOnlySet<TElement> : IEnumerable<TElement>
    {
        private readonly IEnumerable<TElement> _elements;

        public ReadOnlySet(IEnumerable<TElement> elements)
        {
            _elements = elements;
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
