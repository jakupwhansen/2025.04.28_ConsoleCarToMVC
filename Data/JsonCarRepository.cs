using ConsoleCarToMVC.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleCarToMVC.Data
{
    // Repository der gemmer og henter biler fra en JSON-fil
    public class JsonCarRepository : ICarRepository
    {
        private readonly string filePath = "cars.json"; // Filnavn til gemte data

        public List<Car> GetAll()
        {
            if (!File.Exists(filePath))
            {
                // Hvis filen ikke findes, returnerer vi en tom liste
                return new List<Car>();
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Car>>(json) ?? new List<Car>();
        }

        public void Add(Car car)
        {
            var cars = GetAll(); // Hent eksisterende biler
            cars.Add(car);

            string json = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
