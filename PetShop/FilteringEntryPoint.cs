using System;

    public class FilteringEntryPoint<TItem,TProperty> 
    {
        public readonly Func<TItem, TProperty> _selector;
        public bool _negationActive;

        public FilteringEntryPoint(Func<TItem, TProperty> selector) : this(selector, false)
        {
        }

        private FilteringEntryPoint(Func<TItem, TProperty> selector, bool negationActive)
        {
            _selector = selector;
            _negationActive = negationActive;
        }

        public FilteringEntryPoint<TItem, TProperty> Not()
        {
            return new FilteringEntryPoint<TItem, TProperty>(_selector, !_negationActive);
        }
    }
