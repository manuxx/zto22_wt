using System;

namespace Training.Specificaton
{
    internal class FilteringEntryPoint<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _selector;

        public FilteringEntryPoint(Func<TItem, TProperty> selector)
        {
            _selector = selector;
        }
    }
}