using ConsoleCarToMVC;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

// Første skridt mod MVC: 
// Vi flytter al brugerinput og output til en separat View-klasse.
// Program-klassen holder nu mest styr på logikken (controller-rollen).

class Program
{
    private List<Car> cars = new List<Car>();
    private CarView view = new CarView();

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }
    // Constructor - her tilføjer vi 2 biler, så der er noget at vise fra start
    public Program()
    {
        cars.Add(new Car("Toyota", "Corolla", 2020));
        cars.Add(new Car("Ford", "Mustang", 1967));
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            view.ShowMenu();
            string choice = view.ReadChoice();

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
                    view.ShowInvalidChoice();
                    break;
            }
        }
    }

    private void AddCar()
    {
        string brand = view.ReadBrand();
        string model = view.ReadModel();
        int year = view.ReadYear();

        Car car = new Car(brand, model, year);
        cars.Add(car);

        view.ShowCarAdded();
    }

    private void ShowCars()
    {
        if (cars.Count == 0)
        {
            view.ShowNoCars();
        }
        else
        {
            view.ShowCars(cars);
        }
    }
}
