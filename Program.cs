using System;
using System.Collections.Generic;

// Simpel konsolapplikation UDEN MVC – men nu starter vi med 2 biler i systemet.

class Program
{
    private List<Car> cars = new List<Car>();

    // Constructor - kører automatisk, når vi laver en instans af Program
    public Program()
    {
        // Vi tilføjer 2 standardbiler, så der er data fra starten
        cars.Add(new Car("Toyota", "Corolla", 2020));
        cars.Add(new Car("Ford", "Mustang", 1967));
    }

    static void Main(string[] args)
    {
        // Opretter en instans af Program, så vi kan arbejde uden static-metoder
        Program program = new Program();
        program.Run();
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCar();
                    break;
                case "2":
                    ShowCars();
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg. Prøv igen.");
                    break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("\n1. Tilføj bil");
        Console.WriteLine("2. Vis alle biler");
        Console.WriteLine("3. Afslut");
        Console.Write("Vælg en mulighed: ");
    }

    private void AddCar()
    {
        Console.Write("Indtast bilens mærke: ");
        string brand = Console.ReadLine();

        Console.Write("Indtast bilens model: ");
        string model = Console.ReadLine();

        Console.Write("Indtast bilens årgang: ");
        int year;
        while (!int.TryParse(Console.ReadLine(), out year))
        {
            Console.Write("Ugyldigt input. Indtast et gyldigt årstal: ");
        }

        Car car = new Car(brand, model, year);
        cars.Add(car);

        Console.WriteLine("Bil tilføjet!");
    }

    private void ShowCars()
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("Ingen biler oprettet endnu.");
            return;
        }

        Console.WriteLine("\nListe over biler:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Brand} {car.Model} ({car.Year})");
        }
    }
}

// Car-klassen repræsenterer data om en bil.
// Her bruger vi PROPERTIES i stedet for felter af flere vigtige grunde:
//
// ✅ Properties giver bedre kontrol over data – vi kan styre hvordan data læses og ændres.
// ✅ Properties giver mulighed for at tilføje validering, ændring eller logging senere uden at ændre resten af programmet.
// ✅ Properties skaber LAV kobling (low coupling) – vi kan ændre Car-klassen uden at påvirke andre dele af programmet.
// ✅ Properties er STANDARD i MVC-arkitektur (Model-View-Controller).
//    - Når vi arbejder med frameworks som ASP.NET MVC, Entity Framework osv., forventer de properties.
//    - Frameworks kan ikke arbejde direkte med felter – de kræver get/set-metoder bag properties.
// ✅ Ved at bruge properties gør vi Car-klassen klar til fremtidig udvikling, test og integration i større systemer.


class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }
}
