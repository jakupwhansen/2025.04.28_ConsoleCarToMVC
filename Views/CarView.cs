using ConsoleCarToMVC.Models;

namespace ConsoleCarToMVC.Views
{
    // View-klassen håndterer al interaktion med brugeren via Console.
    // Program/Controller snakker med View, ikke direkte med brugeren.

    class CarView : ICarView
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n1. Tilføj bil");
            Console.WriteLine("2. Vis alle biler");
            Console.WriteLine("3. Afslut");
            Console.Write("Vælg en mulighed: ");
        }

        public string ReadChoice()
        {
            return Console.ReadLine();
        }

        public void ShowInvalidChoice()
        {
            Console.WriteLine("Ugyldigt valg. Prøv igen.");
        }

        public string ReadBrand()
        {
            Console.Write("Indtast bilens mærke: ");
            return Console.ReadLine();
        }

        public string ReadModel()
        {
            Console.Write("Indtast bilens model: ");
            return Console.ReadLine();
        }

        public int ReadYear()
        {
            Console.Write("Indtast bilens årgang: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Ugyldigt input. Indtast et gyldigt årstal: ");
            }
            return year;
        }

        public void ShowCarAdded()
        {
            Console.WriteLine("Bil tilføjet!");
        }

        public void ShowNoCars()
        {
            Console.WriteLine("Ingen biler oprettet endnu.");
        }

        public void ShowCars(List<Car> cars)
        {
            Console.WriteLine("\nListe over biler:");
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Brand} {car.Model} ({car.Year})");
            }
        }
    }
}
