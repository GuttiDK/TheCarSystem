using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Data
{
    public interface ICarParking
    { 
        // Create parking spots
        public void CreateParkingSpace();

        // Menu
        public void CarSystemMenu();

        // Pay
        public void Pay();

        // Prices
        public void ChangeMenu();

        // Find cars
        public void PrintCars();


        // Create car wash
        public void CreateCarWash();

        // Get car wash
        public void GetCarWash();
    }
}
