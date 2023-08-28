using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.BLL
{
    public class CarsWash
    {
        int _idCounter;
        string _name;
        List<ParkingSpot> _parking;
        List<CarWash> _wash;
        List<Car> _cars;

        public CarsWash(string name)
        {
            _parking = new List<ParkingSpot>();
            _cars = new List<Car>();
            _wash = new List<CarWash>();
            _name = name;
        }

        public async void StartWash(List<ParkingSpot> parkingLots, CarWash carWash)
        {

        }

        public async Task RunWash(Wash wash)
        {

        }
    }

}
