using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleCarToMVC.Data
{
    public class JsonCarRepository : ICarRepository
    {
        private readonly string filePath = "cars.json";

        // Henter alle CarDTO-objekter fra JSON-filen
        public List<CarDTO> GetAll()
        {
            if (!File.Exists(filePath))
            {
                return new List<CarDTO>();
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<CarDTO>>(json) ?? new List<CarDTO>();
        }

        // Gemmer en CarDTO til JSON-filen
        public void Add(CarDTO car)
        {
            var cars = GetAll();
            cars.Add(car);

            string json = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
