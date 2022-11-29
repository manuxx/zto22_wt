using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Training.DomainClasses
{
    public static class X
    {
        public static ICriteria<Pet> Where<Pet>(Func<IEnumerable<Pet>> expression)
        {
            throw new NotImplementedException();
        }
    }
    
}
