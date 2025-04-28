using System.Collections.Generic;
using ConsoleCarToMVC.Models;

namespace ConsoleCarToMVC.Data
{
    public class DummyCarRepository : ICarRepository
    {
        private List<Car> cars;

        public DummyCarRepository()
        {
            cars = new List<Car>
            {
                new Car("Toyota", "Corolla", 2020),
                new Car("Ford", "Mustang", 1967)
            };
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }
    }
}
