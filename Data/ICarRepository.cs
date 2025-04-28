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
        List<CarDTO> GetAll();  // Henter CarDTO i stedet for Car
        void Add(CarDTO car);   // Gemmer CarDTO
    }

}
