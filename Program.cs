using System;
using ConsoleCarToMVC.Controllers;
using ConsoleCarToMVC.Data;
using ConsoleCarToMVC.Views;

namespace ConsoleCarToMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            // Her vælger vi hvilke implementeringer vi vil bruge
            ICarRepository repository = new DummyCarRepository(); // Eller JsonCarRepository senere
            //repository = new JsonCarRepository(); // Nu bruger vi JSON!
            ICarView view = new CarView(); // Eller ColorCarView
            view = new ColorCarView(); 

            // Vi giver både repository og view videre til controlleren
            CarController controller = new CarController(repository, view);

            controller.Run();
        }
    }
}
