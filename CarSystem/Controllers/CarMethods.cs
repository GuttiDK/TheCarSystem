using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CarSystem.BLL;
using CarSystem.Data;
using CarSystem.Models;

namespace CarSystem.Controllers
{
    public class CarMethods : ICarParking, ICarWash
    {

        /// <summary>
        /// Max parking spots
        /// </summary>
        private readonly int _almindeligMax = 10;
        private readonly int _handicapMax = 3;
        private readonly int _busMax = 5;
        private readonly int _elseMax = 2;
        private readonly int _carwashMax = 3;

        /// <summary>
        /// Counter for ID
        /// </summary>
        int _idCounter;

        /// <summary>
        /// Lists for cars
        /// </summary>
        readonly List<Car> _cars;

        /// <summary>
        /// Lists for parking spots
        /// </summary>
        readonly List<AlmindeligSpot> _almindelig;
        readonly List<HandicapSpot> _handicap;
        readonly List<BusSpot> _bus;
        readonly List<ElseSpot> _else;

        /// <summary>
        /// Lists for carwash
        /// </summary>
        readonly List<CarsWash> _carwash;



        /// <summary>
        /// Constructor
        /// </summary>
        public CarMethods()
        {
            // Lists for parking spots
            _almindelig = new List<AlmindeligSpot>();
            _handicap = new List<HandicapSpot>();
            _bus = new List<BusSpot>();
            _else = new List<ElseSpot>();

            // Lists for carwash
            _carwash = new List<CarsWash>();

            // Lists for parking spots
            _cars = new List<Car>();

            // Counter for ID
            _idCounter++;
        }



        /// <summary>
        /// Prints information about the 'Almindelig' spots.
        /// </summary>
        public void GetAlmindeligSpot()
        {
            if (_almindelig.Count == 0)
            {
                Console.WriteLine($"All normal spots (0/{_almindeligMax}) are available in the system.");
            }
            else
            {
                Console.WriteLine($"Available parking spots: {_almindelig.Count}/{_almindeligMax - _almindelig.Count}");
                foreach (var car in _almindelig)
                {
                    Console.WriteLine($"Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Price: {car.CurrentVehicle.TotalPrice} - {car.CurrentVehicle.ParkingPrice} - {car.Price} - ParkingID {car.Name} - CarID: {car.CurrentVehicle.Id} Parking: {car.IsOccupied} - {car.CurrentVehicle.IsParked}");
                }
            }
            Console.ReadKey();
        }
        public void GetHandicapSpot()
        {
            if (_handicap.Count == 0)
            {
                Console.WriteLine($"All handicap spots (0/{_handicapMax}) are available in the system.");
            }
            else
            {
                Console.WriteLine($"Available parking spots: {_handicap.Count}/{_handicapMax - _handicap.Count}");
                foreach (var car in _handicap)
                {
                    Console.WriteLine($"Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Price: {car.CurrentVehicle.TotalPrice} - {car.CurrentVehicle.ParkingPrice} - {car.Price} - ParkingID {car.Name} - CarID: {car.CurrentVehicle.Id} Parking: {car.IsOccupied} - {car.CurrentVehicle.IsParked}");
                }
            }
            Console.ReadKey();
        }
        public void GetBusSpot()
        {
            if (_bus.Count == 0)
            {
                Console.WriteLine($"All bus spots (0/{_busMax}) are available in the system.");
            }
            else
            {
                Console.WriteLine($"Available parking spots: {_bus.Count}/{_busMax - _bus.Count}");
                foreach (var car in _bus)
                {
                    Console.WriteLine($"Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Price: {car.CurrentVehicle.TotalPrice} - {car.CurrentVehicle.ParkingPrice} - {car.Price} - ParkingID {car.Name} - CarID: {car.CurrentVehicle.Id} Parking: {car.IsOccupied} - {car.CurrentVehicle.IsParked}");
                }
            }
            Console.ReadKey();
        }
        public void GetElseSpot()
        {
            if (_else.Count == 0)
            {
                Console.WriteLine($"All other spots (0/{_elseMax}) are available in the system.");
            }
            else
            {
                Console.WriteLine($"Available parking spots: {_else.Count}/{_elseMax - _else.Count}");
                foreach (var car in _else)
                {
                    Console.WriteLine($"Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Price: {car.CurrentVehicle.TotalPrice} - {car.CurrentVehicle.ParkingPrice} - {car.Price} - ParkingID {car.Name} - CarID: {car.CurrentVehicle.Id} Parking: {car.IsOccupied} - {car.CurrentVehicle.IsParked}");
                }
            }
            Console.ReadKey();
        }


        /// <summary>
        /// Prints information about all parking spots.
        /// </summary>
        public void GetParkingSpots()
        {
            Console.Clear();
            DisplayHeaderFooter(true);
            DisplayParkingInfo("normal", _almindelig.Count, _almindeligMax);
            DisplayParkingInfo("handicap", _handicap.Count, _handicapMax);
            DisplayParkingInfo("bus", _bus.Count, _busMax);
            DisplayParkingInfo("other", _else.Count, _elseMax);

            int totalSpots = _almindelig.Count + _handicap.Count + _bus.Count + _else.Count;
            int totalMax = _almindeligMax + _handicapMax + _busMax + _elseMax;

            Console.WriteLine($"\n There are {totalSpots}/{totalMax - totalSpots} spots in total\n");

            DisplayHeaderFooter(false);
            Console.ReadKey();
        }
        private static void DisplayHeaderFooter(bool isHeader)
        {
            const string separator = "----------------------------------";
            if (isHeader)
            {
                Console.WriteLine(separator);
                Console.WriteLine("\n Cars in the parking lot:\n");
            }
            else
            {
                Console.WriteLine(separator);
            }
        }
        private static void DisplayParkingInfo(string spotType, int currentCount, int maxCount)
        {
            Console.WriteLine($" There are {currentCount}/{maxCount - currentCount} {spotType} spots");
        }


        // This method is the to show all the cars in the carwash
        public void GetCarWashCarsStatus()
        {
        }
        public void GetCarWash()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("");
            Console.WriteLine(" Cars in the carwash:");
            Console.WriteLine("");
            Console.WriteLine($" There are {_carwash.Count}/{_carwashMax - _carwash.Count} cars in the carwash");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
            Console.ReadKey();
        }


        /// <summary>
        /// Her opretter den en ny bil og tilføjer den til en parkeringsplads
        /// </summary>
        /// <param name="car"></param>
        public void CreateParkingSpace()
        {
            Car car = new(InputString("\nInput your licenseplate: "), CreateSpotMenu())
            {
                IsParked = true
            };
            string spotId = "P" + _idCounter++;
            switch (car.Type)
            {
                case CarType.Almindelig:
                    _almindelig.Add(new AlmindeligSpot(spotId, car));
                    break;

                case CarType.Handicap:
                    _handicap.Add(new HandicapSpot(spotId, car));
                    break;

                case CarType.Bus:
                    _bus.Add(new BusSpot(spotId, car));
                    break;

                case CarType.Else:
                    _else.Add(new ElseSpot(spotId, car));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Her opretter den en ny bil eller finder en bil i systemet og tilføjer den til en vask
        /// </summary>
        /// <param></param>
        public void CreateCarWash()
        {
            switch (InputInt("1 = Create new carwash\n2 = Add car to carwash", "Wrong input"))
            {
                case 1:
                    if (_carwash.Count == _carwashMax)
                    {
                        Console.WriteLine("The carwash is full");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        _ = new Car(InputString("\nInput your licenseplate: "), CreateSpotMenu());
                    }
                    break;
                case 2:
                    if (_carwash.Count == _carwashMax)
                    {
                        Console.WriteLine("The carwash is full");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        var test = FindCarPlate(InputString("Input your licenseplate: "));
                        if (test != null)
                        {
                            Console.WriteLine("Car added to carwash");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Car not found");
                            Console.ReadKey();
                        }
                    }
                    break;
            }
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
                DisplayMenu();
                switch (InputInt("Please choose an option: ", "Wrong input"))
                {
                    case 1:
                        if (_almindelig.Count < _almindeligMax)
                        {
                            return CarType.Almindelig;
                        }
                        else
                        {
                            Console.WriteLine("There are no more spots for a normal car");
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        if (_handicap.Count < _handicapMax)
                        {
                            return CarType.Handicap;
                        }
                        else
                        {
                            Console.WriteLine("There are no more spots for a handicap car");
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        if (_bus.Count < _busMax)
                        {
                            return CarType.Bus;
                        }
                        else
                        {
                            Console.WriteLine("There are no more spots for a bus");
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        if (_else.Count < _elseMax)
                        {
                            return CarType.Else;
                        }
                        else
                        {
                            Console.WriteLine("There are no more spots for other cars");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        break;
                }
            } while (true);
        }



        /// <summary>
        /// Paying for parking or washing or both
        /// </summary>
        /// <param name="text"></param>
        /// <returns>list</returns>
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
        private static void DisplayMenu()
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





        /// <summary>
        /// Input vaules
        /// </summary>

        /// <summary>
        /// Prompter the user for input until a non-empty string is provided.
        /// </summary>
        /// <param name="promptMessage">The message to display to the user.</param>
        /// <returns>A non-empty user input string.</returns>
        public string InputString(string promptMessage)
        {
            while (true)
            {
                Console.Write(promptMessage);
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine("Please enter a valid input."); // Optionally provide feedback on empty input
            }
        }

        /// <summary>
        /// Prompts the user to enter an integer. Displays an error message if the input is not a valid integer.
        /// </summary>
        /// <param name="promptMessage">Message displayed to prompt the user for input.</param>
        /// <param name="errorMessage">Message displayed when the user provides an invalid input. If null, a default message will be used.</param>
        /// <returns>The user's input as an integer.</returns>
        public int InputInt(string promptMessage, string errorMessage)
        {
            errorMessage ??= "Wrong input";  // If errorMessage is null, use "Wrong input" as the default
            while (true)
            {
                Console.Write(promptMessage);
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;

                Console.WriteLine(errorMessage);
            }
        }


        /// <summary>
        /// Prompts the user to enter a decimal. Displays an error message if the input is not a valid decimal.
        /// </summary>
        /// <param name="promptMessage">Message displayed to prompt the user for input.</param>
        /// <param name="errorMessage">Message displayed when the user provides an invalid input. If null, a default message will be used.</param>
        /// <returns>The user's input as a decimal.</returns>
        public decimal InputDecimal(string promptMessage, string errorMessage)
        {
            errorMessage ??= "Wrong input";  // If errorMessage is null, use "Wrong input" as the default
            while (true)
            {
                Console.Write(promptMessage);
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                    return result;

                Console.WriteLine(errorMessage);
            }
        }


    }
}
