using System;

public class AnonymousCriteria<TElement> : Criteria<TElement>
{
    private Predicate<TElement>_condition;
    public AnonymousCriteria(Predicate<TElement> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(TElement pet)
    {
        return _condition(pet);
    }
}