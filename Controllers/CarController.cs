using ConsoleCarToMVC.Models;
using ConsoleCarToMVC.Views;


namespace ConsoleCarToMVC.Controllers
{
    // CarController styrer logikken i programmet og arbejder nu med Dependency Injection.

    class CarController
    {
        private List<Car> cars = new List<Car>();
        private ICarView view;

        // Dependency Injection: Controller får View leveret udefra (fra Program)
        public CarController(ICarView view)
        {
            this.view = view;

            // Tilføjer to standardbiler
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
}
