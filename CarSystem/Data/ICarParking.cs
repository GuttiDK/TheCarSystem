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
        public List<AlmindeligSpot> GetAlmindeligSpot();
        public List<Car> GetCars();
    }
}
