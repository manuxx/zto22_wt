using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;
static class CriteriaExtensions
{
    public static BinaryCriteria<TItem> And<TItem>(this ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
    {
        return new Conjuction<TItem>(criteria1, criteria2);
    }

    public static BinaryCriteria<TItem> Or<TItem>(this ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
    {
        return new Alternative<TItem>(criteria1, criteria2);
    }
}