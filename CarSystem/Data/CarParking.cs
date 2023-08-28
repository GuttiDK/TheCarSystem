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
    }
}
