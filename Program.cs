using System;
using ConsoleCarToMVC;

namespace ConsoleCarToMVC
{
    // Program-klassen er nu kun ansvarlig for at starte programmet.
    // Den skaber en Controller og kalder dens Run()-metode.
    class Program
    {
        static void Main(string[] args)
        {
            CarController controller = new CarController();
            controller.Run();
        }
    }
}
