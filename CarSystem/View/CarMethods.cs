using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data;
using CarSystem.Models;

namespace CarSystem.View
{
    public class CarMethods : ICarParking
    {
        private readonly int _almindeligMax = 10;
        private readonly int _handicapMax = 3;
        private readonly int _busMax = 5;
        private readonly int _freeMax = 2;

        int _idCounter;
        List<Car> _cars;

        List<AlmindeligSpot> _almindelig;
        List<HandicapSpot> _handicap;
        List<BusSpot> _bus;
        List<FreeSpot> _free;



        public CarMethods()
        {
            _almindelig = new List<AlmindeligSpot>();
            _handicap = new List<HandicapSpot>();
            _bus = new List<BusSpot>();
            _free = new List<FreeSpot>();

            _cars = new List<Car>();
            _idCounter++;
        }


        public List<AlmindeligSpot> GetAlmindeligSpot()
        {
            return _almindelig;
        }

        public List<Car> GetCars()
        {
            return _cars;
        }

        /// <summary>
        /// Her finder den bilen ud fra licenspladen
        /// </summary>
        /// <param name="car"></param>
        public void CreateParkingSpace(Car car)
        {
            if (car != null)
            {
                if (car.Type == CarType.Almindelig && _almindelig.Count() < _almindeligMax)
                {
                    car.IsParked = true;
                    _almindelig.Add(new AlmindeligSpot(_idCounter++, ("P" + _idCounter++), car  ));
                }
                if (car.Type == CarType.Handicap && _handicap.Count() < _handicapMax)
                {
                    car.IsParked = true;
                    _handicap.Add(new HandicapSpot(_idCounter++, ("P" + _idCounter++), car));
                }
                if (car.Type == CarType.Bus && _bus.Count() < _busMax)
                {
                    car.IsParked = true;
                    _bus.Add(new BusSpot(_idCounter++, ("P" + _idCounter++), car));
                }
                if (car.Type == CarType.Free && _free.Count() < _freeMax)
                {
                    car.IsParked = true;
                    _free.Add(new FreeSpot(_idCounter++, ("P" + _idCounter++), car));
                }
            }



        }

        /// <summary>
        /// Her finder den bilen ud fra licenspladen
        /// </summary>
        /// <param name="carName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Car FindAccountName(string? carName)
        {
            if (carName != null)
            {
                return _cars.First(x => x.LicensePlate == carName);
            }
            else
            {
                throw new Exception("No car found");
            }
        }

        /// <summary>
        /// Her finder den bilen ud fra id
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Car FindAccountId(int? carId)
        {
            if (carId != null)
            {
                return _cars.First(x => x.Id == carId);
            }
            else
            {
                throw new Exception("No car found");
            }
        }
    }
}
