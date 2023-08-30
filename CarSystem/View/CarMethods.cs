using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CarSystem.BLL;
using CarSystem.Data;
using CarSystem.Models;

namespace CarSystem.View
{
    public class CarMethods : ICarParking, ICarWash
    {
        private readonly int _almindeligMax = 10;
        private readonly int _handicapMax = 3;
        private readonly int _busMax = 5;
        private readonly int _elseMax = 2;

        int _idCounter;
        List<Car> _cars;
        List<ParkingSpot> _parkingSpots;
       
        List<AlmindeligSpot> _almindelig;
        List<HandicapSpot> _handicap;
        List<BusSpot> _bus;
        List<ElseSpot> _else;



        public CarMethods()
        {
            _almindelig = new List<AlmindeligSpot>();
            _handicap = new List<HandicapSpot>();
            _bus = new List<BusSpot>();
            _else = new List<ElseSpot>();

            _parkingSpots = new List<ParkingSpot>();
            _cars = new List<Car>();
            _idCounter++;
        }

        public void GetAlmindeligSpot()
        {
            if (_almindelig.Count() == 0)
            {
                Console.WriteLine($"\nDer er {_almindelig.Count()} almindelige pladser i systemet");
            }
            else
            {
                foreach (var car in _almindelig)
                {
                    Console.WriteLine($"Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Price: {car.CurrentVehicle.TotalPrice} - {car.CurrentVehicle.ParkingPrice} - {car.Price} - ParkingID {car.Name} - CarID: {car.CurrentVehicle.Id} Parking: {car.IsOccupied} - {car.CurrentVehicle.IsParked}");
                }
            }
            Console.ReadKey();
        }

        public void GetHandicapSpot()
        {
            if (_handicap.Count() == 0)
            {
                Console.WriteLine($"Der er {_handicap.Count()} handicap pladser i systemet");
            }
            else
            {
                foreach (var car in _handicap)
                {
                    Console.WriteLine($"Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Price: {car.CurrentVehicle.TotalPrice} - {car.CurrentVehicle.ParkingPrice} - {car.Price} - ParkingID {car.Name} - CarID: {car.CurrentVehicle.Id} Parking: {car.IsOccupied} - {car.CurrentVehicle.IsParked}");
                }
            }
        }

        public void GetBusSpot()
        {
            if (_bus.Count() == 0)
            {
                Console.WriteLine($"\nDer er {_bus.Count()} bus pladser i systemet");
                throw new Exception("Der er ingen bus pladser i systemet");
            }
            else
            {
                foreach (var car in _bus)
                {
                    Console.WriteLine($"Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Price: {car.CurrentVehicle.TotalPrice} - {car.CurrentVehicle.ParkingPrice} - {car.Price} - ParkingID {car.Name} - CarID: {car.CurrentVehicle.Id} Parking: {car.IsOccupied} - {car.CurrentVehicle.IsParked}");
                }
            }
        }

        public void GetElseSpot()
        {
            if (_else.Count() == 0)
            {
                Console.WriteLine($"\nDer er {_else.Count()} andre pladser i systemet");
                throw new Exception("Der er ingen andre pladser i systemet");
                Console.ReadKey();
            }
            else
            {
                foreach (var car in _else)
                {
                    Console.WriteLine($"Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Price: {car.CurrentVehicle.TotalPrice} - {car.CurrentVehicle.ParkingPrice} - {car.Price} - ParkingID {car.Name} - CarID: {car.CurrentVehicle.Id} Parking: {car.IsOccupied} - {car.CurrentVehicle.IsParked}");
                }
                Console.ReadKey();
            }
        }

        public void ParkingSpots()
        {
            if (_parkingSpots.Count() == 0)
            {
                Console.WriteLine($"\nDer er {_parkingSpots.Count()} pladser i systemet");
            }
            else
            {
                foreach (var car in _parkingSpots)
                {
                    Console.WriteLine($"Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Price: {car.CurrentVehicle.TotalPrice} - {car.CurrentVehicle.ParkingPrice} - {car.Price} - ParkingID {car.Name} - CarID: {car.CurrentVehicle.Id} Parking: {car.IsOccupied} - {car.CurrentVehicle.IsParked}");
                }
            }
            Console.ReadKey();
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
                    _almindelig.Add(new AlmindeligSpot(("P" + _idCounter++), car));
                }
                if (car.Type == CarType.Handicap && _handicap.Count() < _handicapMax)
                {
                    car.IsParked = true;
                    _handicap.Add(new HandicapSpot(("P" + _idCounter++), car));
                }
                if (car.Type == CarType.Bus && _bus.Count() < _busMax)
                {
                    car.IsParked = true;
                    _bus.Add(new BusSpot(("P" + _idCounter++), car));
                }
                if (car.Type == CarType.Else && _else.Count() < _elseMax)
                {
                    car.IsParked = true;
                    _else.Add(new ElseSpot(("P" + _idCounter++), car));
                }
            }
        }


        public void Pay()
        {
            bool runtime = true;
            while (runtime == true)
            {
                Console.Clear();
                Console.WriteLine("|----------------------------------|");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can chose the following:     |");
                Console.WriteLine("| 1 = Pay for parking              |");
                Console.WriteLine("| 2 = Pay for washing              |");
                Console.WriteLine("| 3 = Pay for both                 |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can leave by following:      |");
                Console.WriteLine("| 4 = Go back to main menu         |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|----------------------------------|");
                Console.Write("Please choose an option: ");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        Paying(1);
                        runtime = false;
                        break;
                    case ConsoleKey.D2:
                        Paying(2);
                        runtime = false;
                        break;
                    case ConsoleKey.D3:
                        Paying(3);
                        runtime = false;
                        break;
                    case ConsoleKey.D4:
                        runtime = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Paying(int option)
        {
            if (option == 1)
            {

            }
            if (option == 2)
            {

            }
            if (option == 3)
            {

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
            Console.WriteLine("| w = Start Washing Car            |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("| s = Status of Parking            |");
            Console.WriteLine("| o = Status of CarWash            |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("| b = Show Prices and Lots         |");
            Console.WriteLine("| r = Pay for car                  |");
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
                Console.WriteLine("| 4 = Else                         |");
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
                        return CarType.Else;
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
        public Car FindCarPlate(string? carName)
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
        public Car FindCarId(int? carId)
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
