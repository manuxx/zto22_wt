using System;

namespace Training.Specificaton
{
    internal class FilteringEntryPoint<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _selector;
        public  bool _negation;

        public FilteringEntryPoint(Func<TItem, TProperty> selector)
        {
            _selector = selector;
            _negation = false;

        }

        public FilteringEntryPoint<TItem, TProperty> Negate()
        {
            _negation = !_negation;
            return this;
        }
    }
}