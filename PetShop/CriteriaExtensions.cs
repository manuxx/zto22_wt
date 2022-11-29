using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Training.DomainClasses;

namespace PetShop
{
    public static class CriteriaExtensions
    {
        public static BinaryCriteria<TItem> And<TItem>(this ICriteria<TItem> leftCriteria, ICriteria<TItem> rightCriteria)
        {
            return new Conjunction<TItem>(leftCriteria, rightCriteria);
        }

        public static Alternative<TItem> Or<TItem>(this ICriteria<TItem> leftCriteria, ICriteria<TItem> rightCriteria)
        {
            return new Alternative<TItem>(leftCriteria, rightCriteria);
        }
    }
}
