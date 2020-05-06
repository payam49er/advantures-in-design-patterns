using System;
using SOLID.SpecificationPattern;

namespace SOLID
{
    class Program
    {
        static void Main ( string[] args )
        {
            //create a journal
            var journal = new Journal();
            //create persistance
            var p = new Persist();
            p.SaveToFile(journal,"");


            //specification pattern for open / close principle
            Product[] products = new Product[3];
            var product1 = new Product()
            {
                color = Color.blue,
                Name = "product1",
                Size = Size.small
            };
            var product2 = new Product()
            {
                color = Color.green,
                Name = "product2",
                Size = Size.large
            };
            var product3 = new Product()
            {
                color = Color.red,
                Name = "Product3",
                Size = Size.XLarge
            };
            products[0] = product1;
            products[1] = product2;
            products[2] = product3;


            var bf = new BetterFilter();
            bf.Filter(products, new ColorSpecification());
            bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(),new SizeSpecification()));

        }
    }
}
