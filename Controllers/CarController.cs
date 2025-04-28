using ConsoleCarToMVC.Models;
using ConsoleCarToMVC.Data;
using ConsoleCarToMVC.Views;
using System.Collections.Generic;

namespace ConsoleCarToMVC.Controllers
{
    // Controlleren styrer flowet mellem View og Repository.
    // Den opretter ikke længere egne biler – alt data kommer fra Repository.

    public class CarController
    {
        private readonly ICarRepository repository;
        private readonly ICarView view;

        // Dependency Injection: både repository og view leveres udefra
        public CarController(ICarRepository repository, ICarView view)
        {
            this.repository = repository;
            this.view = view;
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

        // Tilføjer en ny bil via Repository
        private void AddCar()
        {
            string brand = view.ReadBrand();
            string model = view.ReadModel();
            int year = view.ReadYear();

            Car car = new Car(brand, model, year);
            repository.Add(car); // Gemmer bilen via repository

            view.ShowCarAdded();
        }

        // Viser alle biler ved at hente dem fra Repository
        private void ShowCars()
        {
            var cars = repository.GetAll(); // Henter alle biler fra repository

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
}
