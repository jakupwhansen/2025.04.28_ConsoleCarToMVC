using ConsoleCarToMVC.Models;

namespace ConsoleCarToMVC.Views
{
    class ColorCarView : ICarView
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ugyldigt valg. Prøv igen.");
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Ugyldigt input. Indtast et gyldigt årstal: ");
                Console.ResetColor();
            }
            return year;
        }

        public void ShowCarAdded()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bil tilføjet!");
            Console.ResetColor();
        }

        public void ShowNoCars()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingen biler oprettet endnu.");
            Console.ResetColor();
        }

        public void ShowCars(List<Car> cars)
        {
            Console.WriteLine("\nListe over biler:");
            foreach (var car in cars)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(car.Brand + " ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(car.Model + " ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("(" + car.Year + ")");
                Console.ResetColor();
            }
        }
    }
}
