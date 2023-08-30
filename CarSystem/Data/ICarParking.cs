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
        public void CreateParkingSpace(Car car);
        public void GetAlmindeligSpot();
        public void GetHandicapSpot();
        public void GetBusSpot();
        public void GetElseSpot();
        public void ParkingSpots();
        public List<Car> GetCars();
        public CarType CreateSpotMenu();
        public void CarSystemMenu();
        public void Pay();


        public string InputString(string message);
        public int InputInt(string text, string error);
        public decimal InputDecimal(string text, string error);
    }
}
