using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Data
{
    public class CarParking
    {
        private readonly string _name;
        private readonly ICarParking _repo;

        public CarParking(ICarParking repo)
        {
            _name = "CarSystem";
            _repo = repo;
        }



        public void CarSystemMenu()
        {
            _repo.CarSystemMenu();
        }

        public void CreateParkingSpace(Car car)
        {
            _repo.CreateParkingSpace(car);
        }

        public List<AlmindeligSpot> GetAlmindeligSpot()
        {
            return _repo.GetAlmindeligSpot();
        }

        public List<Car> GetCars()
        {
            return _repo.GetCars();
        }

        public CarType CreateSpotMenu()
        {
            return _repo.CreateSpotMenu();
        }
        



        /// <summary>
        /// Inputs a value and returns it
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string InputString(string message)
        {
            return _repo.InputString(message);
        }
        public int InputInt(string text, string error)
        {
            return _repo.InputInt(text, error);
        }
        public decimal InputDecimal(string text, string error)
        {
            return _repo.InputDecimal(text, error);
        }

    }
}
