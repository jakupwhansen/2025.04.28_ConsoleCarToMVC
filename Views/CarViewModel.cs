using ConsoleCarToMVC.Models;

namespace ConsoleCarToMVC.Views
{
    public class CarViewModel
    {
        public string DisplayName { get; set; }
        public int Age { get; set; }

        // Konstruktør, der tager en Car og mapper til ViewModel
        public CarViewModel(Car car)
        {
            DisplayName = $"{car.Brand} {car.Model}";
            Age = System.DateTime.Now.Year - car.Year;
        }
    }
}
