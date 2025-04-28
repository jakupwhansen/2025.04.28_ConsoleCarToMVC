using ConsoleCarToMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCarToMVC.Data
{
    public interface ICarRepository
    {
        List<Car> GetAll();
        void Add(Car car);
    }
}
