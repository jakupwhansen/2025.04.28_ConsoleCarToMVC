using ConsoleCarToMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCarToMVC.Views
{
    public interface ICarView
    {
        void ShowMenu();
        string ReadChoice();
        void ShowInvalidChoice();
        string ReadBrand();
        string ReadModel();
        int ReadYear();
        void ShowCarAdded();
        void ShowCars(List<CarViewModel> carViewModels);  // Ændret til CarViewModel
        void ShowNoCars();
    }
}
