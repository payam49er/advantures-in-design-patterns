using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.AbstractFactory
{
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
}
