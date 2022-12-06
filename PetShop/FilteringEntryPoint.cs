using System;

namespace Training.Specificaton
{
    public class FilteringEntryPoint<TItem,TProperty>
    {
        public readonly Func<TItem, TProperty> _selector;
        public readonly bool _negationActive;

        public FilteringEntryPoint(Func<TItem, TProperty> selector) : this(selector, false)
        {}

        public FilteringEntryPoint(Func<TItem, TProperty> selector, bool negationActive)
        {
            _selector = selector;
            _negationActive = negationActive;
        }
    }
}