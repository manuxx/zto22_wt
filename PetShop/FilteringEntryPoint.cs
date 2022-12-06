using System;

    public class FilteringEntryPoint<TItem,TProperty> 
    {
        public readonly Func<TItem, TProperty> _selector;
        public bool _negationActive = false;

        public FilteringEntryPoint(Func<TItem, TProperty> selector)
        {
            _selector = selector;
        }

        public FilteringEntryPoint<TItem, TProperty> Not()
        {
            if(_negationActive == true)
            {
                _negationActive = false;
            }
            else
            {
                _negationActive = true;
            }
            return this;
        }
}
