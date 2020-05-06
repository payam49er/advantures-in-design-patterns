using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    public interface ISpecification<T>
    {
        // the only method that specification patter must have. We allo users to make specification, and we want to make sure that type T satisfies some specification
        bool IsSatisfied(T t);
    }

    //this interface enforces a filtering mechanism over the items type of T
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
}
