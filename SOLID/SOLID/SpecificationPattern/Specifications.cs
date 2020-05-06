using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SOLID.SpecificationPattern
{
     public class ColorSpecification:ISpecification<Product>
     {
         private Color color;
         //there has to be a method to set the color
        public bool IsSatisfied(Product t)
        {
            return t.color == color;
        }
    }

     public class BetterFilter : IFilter<Product>
     {
         public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
         {
             foreach (Product product in items)
             {
                 if (spec.IsSatisfied(product))
                     yield return product;
             }
         }
     }

     public class AndSpecification<T> : ISpecification<T>
     {
         private ISpecification<T> first, second;
        public AndSpecification(ISpecification<T> first,ISpecification<T> second)
        {
            first = this.first;
            second = this.second;
        }
        
         public bool IsSatisfied(T t)
         {
             return first.IsSatisfied(t) && second.IsSatisfied(t);
         }
     }

     public class SizeSpecification : ISpecification<Product>
     {
         private Size size;
         public bool IsSatisfied(Product t)
         {
             return t.Size == size;
         }
     }
}
