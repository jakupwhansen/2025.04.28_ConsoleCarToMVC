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

            // Mapper Car til CarDTO
            CarDTO carDto = new CarDTO(brand, model, year);  // Opretter CarDTO i stedet for Car

            // Sender CarDTO til Repository
            repository.Add(carDto);  // Gemmer bilen via Repository

            view.ShowCarAdded();
        }


        // Viser alle biler ved at hente dem fra Repository
        private void ShowCars()
        {
            var carDTOs = repository.GetAll(); // Henter CarDTO-objekter fra Repository

            if (carDTOs.Count == 0)
            {
                view.ShowNoCars();
            }
            else
            {
                var carViewModels = new List<CarViewModel>();

                foreach (var carDto in carDTOs)
                {
                    // Mapper CarDTO til Car (Model)
                    var car = new Car(carDto.Brand, carDto.Model, carDto.Year);

                    // Mapper Car til CarViewModel
                    carViewModels.Add(new CarViewModel(car));
                }

                view.ShowCars(carViewModels);  // Sender CarViewModel til View
            }
        }

    }
}
