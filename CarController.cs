using System.Collections.Generic;

namespace ConsoleCarToMVC
{
    // CarController styrer programmets logik.
    // Den håndterer brugerens valg og styrer samarbejdet mellem View og Model.

    class CarController
    {
        private List<Car> cars = new List<Car>();  // Liste til at gemme bilerne
        private ICarView view;                      // Bruger interface så vi kan skifte View fleksibelt

        public CarController()
        {
            // Her vælger vi hvilket View vi vil bruge.
            // view = new CarView();
            view = new ColorCarView();

            // Tilføjer to standardbiler så der er noget data fra starten
            cars.Add(new Car("Toyota", "Corolla", 2020));
            cars.Add(new Car("Ford", "Mustang", 1967));
        }

        // Run-metoden styrer hovedflowet i applikationen
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

        // Tilføjer en ny bil baseret på brugerinput
        private void AddCar()
        {
            string brand = view.ReadBrand();
            string model = view.ReadModel();
            int year = view.ReadYear();

            Car car = new Car(brand, model, year);
            cars.Add(car);

            view.ShowCarAdded();
        }

        // Viser alle biler til brugeren
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
