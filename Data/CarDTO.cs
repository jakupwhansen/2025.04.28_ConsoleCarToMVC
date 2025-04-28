namespace ConsoleCarToMVC.Data
{
    public class CarDTO
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }  // Vi beholder Year her, så det kan bruges til at oprette en Car

        // Constructor til at initialisere CarDTO
        public CarDTO(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }
    }
}
