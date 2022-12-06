using System;

    public class FilteringEntryPoint<TItem,TProperty> 
    {
        public readonly Func<TItem, TProperty> _selector;
        public bool _negationActive;

        public FilteringEntryPoint(Func<TItem, TProperty> selector)
        {
            _selector = selector;
        }


        public FilteringEntryPoint<TItem, TProperty> Not()
        {
            _negationActive = !_negationActive;
            return this;
        }
    }
