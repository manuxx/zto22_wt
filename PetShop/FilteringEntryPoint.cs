using System;

    public class FilteringEntryPoint<TItem,TProperty> 
    {
        public readonly Func<TItem, TProperty> _selector;
        public readonly bool _negation;

        public FilteringEntryPoint(Func<TItem, TProperty> selector)
        {
            _selector = selector;
            _negation = false;
        }
        
        private FilteringEntryPoint(Func<TItem, TProperty> selector, bool negation)
        {
            _selector = selector;
            _negation = negation;
        }

        public FilteringEntryPoint<TItem, TProperty> Not()
        {
            return new FilteringEntryPoint<TItem, TProperty>(item => _selector(item), !_negation);
        }
    }
