using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            if (_cars.Count() == 0)
            {
                throw new Exception("Der er ingen biler i systemet");
            }
            else
            {
                return _cars;
            }
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
        /// Her sender den menupunktet tilbage
        /// </summary>
        public void CarSystemMenu()
        {
            Console.Clear();
            Console.WriteLine("|----------------------------------|");
            Console.WriteLine("|                                  |");
            Console.WriteLine("| You can chose the following:     |");
            Console.WriteLine("| p = Start Parking                |");
            Console.WriteLine("| s = Stop Parking                 |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("| w = Start Washing Car            |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("| r = Show Prices and Lots         |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("| You can leave by following:      |");
            Console.WriteLine("| x = Exit                         |");
            Console.WriteLine("|----------------------------------|");
            Console.Write("Please choose an option: ");
        }


        /// <summary>
        /// Writeline and readline returning a cartype
        /// </summary>
        /// <param name="text"></param>
        /// <returns>list</returns>
        public CarType CreateSpotMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("|----------------------------------|");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can chose the following:     |");
                Console.WriteLine("| 1 = Almindelig                   |");
                Console.WriteLine("| 2 = Handicap                     |");
                Console.WriteLine("| 3 = Bus                          |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|----------------------------------|");
                switch (InputInt("Please choose an option: ", "Wrong input"))
                {
                    case 1:
                        return CarType.Almindelig;
                    case 2:
                        return CarType.Handicap;
                    case 3:
                        return CarType.Bus;
                    case 4:
                        return CarType.Free;
                    default:
                        break;
                }
            } while (true);
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

        public void CreateParkingSpace()
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// Input vaules
        /// </summary>

        /// <summary>
        /// Writeline and readline returning string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public string InputString(string text)
        {
            while (true)
            {
                Console.Write(text);
                string input = Console.ReadLine();
                if (input.Length > 0)
                    return input;
            }
        }

        /// <summary>
        /// Writeline and readline returning int
        /// </summary>
        /// <param name="text"></param>
        /// <returns>int</returns>
        public int InputInt(string text, string error)
        {
            if (error == null)
            {
                error = "Wrong input";
            }
            int output;
            bool isValid = false;
            do
            {
                Console.Write(text);
                isValid = int.TryParse(Console.ReadLine(), out output);
                if (isValid)
                {
                    Console.WriteLine(error);
                }
            }
            while (!isValid);
            return output;
        }

        /// <summary>
        /// Writeline and readline returning only demical
        /// </summary>
        /// <param name="text"></param>
        /// <returns>demical</returns>
        public decimal InputDecimal(string text, string error)
        {
            if (error == null)
            {
                error = "Wrong input";
            }
            decimal output;
            bool isValid = false;
            do
            {
                Console.Write(text);
                isValid = decimal.TryParse(Console.ReadLine(), out output);
                if (isValid)
                {
                    Console.WriteLine(error);
                }
            }
            while (!isValid);
            return output;
        }

    }
}
