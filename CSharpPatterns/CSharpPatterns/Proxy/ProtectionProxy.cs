using System;


namespace CSharpPatterns.Proxy
{
    public interface ICar
    {
        void Drive();
    }
    public class Car:ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car is being driven");
        }
    }



    public class CarProxy:ICar
    {
        private Driver driver;
        private Car car = new Car();
        public CarProxy(Driver driver)
        {
            this.driver = driver;
            
        }
        public void Drive()
        {
            if(driver.Age >= 16)
                car.Drive();
            else
            {
                Console.WriteLine("You are too young to drive");
            }
        }
    }

    public class Driver
    {
        public int Age { get; set; }
    }
    
}
