using System;

    public class Where<TItem>
    {
        public static FilteringEntryPoint<TItem,TProperty> HasAn<TProperty>(Func<TItem, TProperty> selector) 
        {
            return new FilteringEntryPoint<TItem,TProperty>(selector);
        }
    }
