using ConsoleCarToMVC.Data;

public class DummyCarRepository : ICarRepository
{
    private List<CarDTO> cars;  // Vi bruger List<CarDTO> her

    public DummyCarRepository()
    {
        cars = new List<CarDTO>
        {
            new CarDTO("Toyota", "Corolla", 2020),
            new CarDTO("Ford", "Mustang", 1967)
        };
    }

    public List<CarDTO> GetAll()
    {
        return cars;
    }

    public void Add(CarDTO car)
    {
        cars.Add(car);
    }
}
