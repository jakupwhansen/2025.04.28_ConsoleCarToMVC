using System;
using ConsoleCarToMVC.Controllers;
using ConsoleCarToMVC.Views;

namespace ConsoleCarToMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            // Her vælger vi hvilket View vi vil bruge
            ICarView view = new ColorCarView(); // eller new CarView();
            CarController controller = new CarController(view);
            controller.Run();
        }
    }
}
