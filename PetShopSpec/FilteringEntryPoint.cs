using System;

namespace Training.Specificaton
{
    internal class FilteringEntryPoint<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _selector;
        public  bool _negation;


        public FilteringEntryPoint(Func<TItem, TProperty> selector):this(selector,false)
        {

        }
        private FilteringEntryPoint(Func<TItem, TProperty> selector,bool negation)
        {
            _selector = selector;
            _negation = negation;
        }

        public FilteringEntryPoint<TItem, TProperty> Negate()
        {
            return new FilteringEntryPoint<TItem, TProperty>(_selector, !_negation);
        }
    }
}