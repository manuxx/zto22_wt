using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class Utils
    {
        public static IEnumerable<TItem> EachElement<TItem>(IEnumerable<TItem> collection)
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }
    }
}