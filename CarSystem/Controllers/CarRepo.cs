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
    public class CarRepo : ICarParking, ICarWash
    {
        #region Properties
        /// <summary>
        /// Counter for ID
        /// </summary>
        private int _idCounter;

        /// <summary>
        /// Max parking spots
        /// </summary>
        private int _almindeligMax;
        private int _handicapMax;
        private int _busMax;
        private int _otherMax;
        private int _carwashMax;

        /// <summary>
        /// Prices
        /// </summary>
        private decimal _almindeligPrice;
        private decimal _handicapPrice;
        private decimal _busPrice;
        private decimal _otherPrice;
        private decimal _carwashPrice;

        /// <summary>
        /// Lists for parking spots
        /// </summary>
        readonly List<AlmindeligSpot> _almindelig;
        readonly List<HandicapSpot> _handicap;
        readonly List<BusSpot> _bus;
        readonly List<OtherSpot> _other;
        readonly List<ParkingSpot> _parkingSpots;

        /// <summary>
        /// Lists for carwash
        /// </summary>
        readonly List<StartWash> _carwash;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CarRepo()
        {

            #region Counter for ID
            // Counter for ID
            _idCounter++;
            #endregion

            #region Max for parking spots and carwash
            // Max for parking spots and carwash
            _almindeligMax = 10;
            _handicapMax = 3;
            _busMax = 5;
            _otherMax = 2;
            _carwashMax = 5;
            #endregion

            #region Prices for parking spots and carwash
            // Prices for parking spots and carwash
            _almindeligPrice = 100;
            _handicapPrice = 50;
            _busPrice = 150;
            _otherPrice = 200;
            _carwashPrice = 300;
            #endregion

            #region Parking spots
            // Lists for parking spots
            _almindelig = new List<AlmindeligSpot>();
            _handicap = new List<HandicapSpot>();
            _bus = new List<BusSpot>();
            _other = new List<OtherSpot>();
            _parkingSpots = new List<ParkingSpot>();
            #endregion

            #region CarWash
            // Lists for carwash
            _carwash = new List<StartWash>();
            #endregion
        }
        #endregion

        #region Methods for parking and carwash
        #region Method for changing prices and max
        public void ChangeMenu()
        {
            bool runtime = true;
            while (runtime == true)
            {
                int totalSpots = _almindelig.Count + _handicap.Count + _bus.Count + _other.Count;
                int totalMax = _almindeligMax + _handicapMax + _busMax + _otherMax;
                Console.Clear();
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Current prices and max for parking:");
                Console.WriteLine($"Almindelig: {_almindeligPrice:C} | ({_almindelig.Count}/{_almindeligMax})");
                Console.WriteLine($"Handicap: {_handicapPrice:C} | ({_handicap.Count}/{_handicapMax})");
                Console.WriteLine($"Bus: {_busPrice:C} | ({_bus.Count}/{_busMax})");
                Console.WriteLine($"Else: {_otherPrice:C} | ({_other.Count}/{_otherMax})");
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Current prices and max for carwash:");
                Console.WriteLine($"Carwash: {_carwashPrice:C} | ({_carwash.Count}/{_carwashMax})");
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Total of all parking spots: {totalSpots}/{totalMax}");
                Console.WriteLine($"Total for carwash: {_carwash.Count}/{_carwashMax}");
                Console.WriteLine("----------------------------------");
                Console.Write(" 1. Change prices\n 2. Change max\n 0. Exit\n\nPlease choose an option: ");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        ChangePrice();
                        break;
                    case ConsoleKey.D2:
                        ChangeMax();
                        break;
                    case ConsoleKey.D0:
                        runtime = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
        }
        public void ChangePrice()
        {
            bool runtime = true;
            while (runtime == true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"1. Almindelig - {_almindeligPrice:C}");
                Console.WriteLine($"2. Handicap - {_handicapPrice:C}");
                Console.WriteLine($"3. Bus - {_busPrice:C}");
                Console.WriteLine($"4. Else - {_otherPrice:C}");
                Console.WriteLine($"5. Carwash - {_carwashPrice:C}");
                Console.WriteLine("0. Exit");
                Console.WriteLine("----------------------------------");
                Console.Write("Choose a price to change: ");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        _almindeligPrice = InputDecimal("\nNew price for normal spot: ", null);
                        break;
                    case ConsoleKey.D2:
                        _handicapPrice = InputDecimal("\nNew price for handicap spot: ", null);
                        break;
                    case ConsoleKey.D3:
                        _busPrice = InputDecimal("\nNew price for bus spot: ", null);
                        break;
                    case ConsoleKey.D4:
                        _otherPrice = InputDecimal("\nNew price for other spot: ", null);
                        break;
                    case ConsoleKey.D5:
                        _carwashPrice = InputDecimal("\nNew price for carwash: ", null);
                        break;
                    case ConsoleKey.D0:
                        runtime = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void ChangeMax()
        {
            bool runtime = true;
            while (runtime == true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"1. Almindelig - ({_almindeligMax}) spots");
                Console.WriteLine($"2. Handicap - ({_handicapMax}) spots");
                Console.WriteLine($"3. Bus - ({_busMax}) spots");
                Console.WriteLine($"4. Other - ({_otherMax}) spots");
                Console.WriteLine($"5. Carwash - ({_carwashMax}) spots");
                Console.WriteLine("0. Exit");
                Console.WriteLine("----------------------------------");
                Console.Write("Choose a max to change: ");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        _almindeligMax = InputInt("\nNew max for normal spot: ", null);
                        break;
                    case ConsoleKey.D2:
                        _handicapMax = InputInt("\nNew max for handicap spot: ", null);
                        break;
                    case ConsoleKey.D3:
                        _busMax = InputInt("\nNew max for bus spot: ", null);
                        break;
                    case ConsoleKey.D4:
                        _otherMax = InputInt("\nNew max for other spot: ", null);
                        break;
                    case ConsoleKey.D5:
                        _carwashMax = InputInt("\nNew max for carwash: ", null);
                        break;
                    case ConsoleKey.D0:
                        runtime = false;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Prints information about all parking spots.
        public void GetParkingSpots()
        {
            Console.Clear();
            DisplayHeaderFooter(true);
            DisplayParkingInfo("normal", _almindelig.Count, _almindeligMax);
            DisplayParkingInfo("handicap", _handicap.Count, _handicapMax);
            DisplayParkingInfo("bus", _bus.Count, _busMax);
            DisplayParkingInfo("other", _other.Count, _otherMax);

            int totalSpots = _almindelig.Count + _handicap.Count + _bus.Count + _other.Count;
            int totalMax = _almindeligMax + _handicapMax + _busMax + _otherMax;

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
        public void GetSpots(int input)
        {
            switch (input)
            {
                case 1:
                    if (_almindelig.Count == 0)
                    {
                        Console.WriteLine($"\nAll normal spots (0/{_almindeligMax}) are available in the system.");
                    }
                    else
                    {
                        Console.WriteLine($"\nAvailable parking spots: ( {_almindelig.Count} / {_almindeligMax - _almindelig.Count} )");
                        foreach (var car in _almindelig)
                        {
                            Console.WriteLine($"Timestamp: {car.CurrentVehicle.ArrivalTime.ToShortDateString()} - Spot/ID: {car.Name}/{car.CurrentVehicle.Id} - Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Parking: {car.CurrentVehicle.IsParked} - Price: {car.CurrentVehicle.TotalPrice:C}");
                        }
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    if (_handicap.Count == 0)
                    {
                        Console.WriteLine($"\nAll handicap spots (0/{_handicapMax}) are available in the system.");
                    }
                    else
                    {
                        Console.WriteLine($"\nAvailable parking spots: ( {_handicap.Count} / {_handicapMax - _handicap.Count} )");
                        foreach (var car in _handicap)
                        {
                            Console.WriteLine($"Timestamp: {car.CurrentVehicle.ArrivalTime.ToShortDateString()} - Spot/ID: {car.Name}/{car.CurrentVehicle.Id} - Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Parking: {car.CurrentVehicle.IsParked} - Price: {car.CurrentVehicle.TotalPrice:C}");
                        }
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    if (_bus.Count == 0)
                    {
                        Console.WriteLine($"\nAll bus spots (0/{_busMax}) are available in the system.");
                    }
                    else
                    {
                        Console.WriteLine($"\nAvailable parking spots: ( {_bus.Count} / {_busMax - _bus.Count} )");
                        foreach (var car in _bus)
                        {
                            Console.WriteLine($"Timestamp: {car.CurrentVehicle.ArrivalTime.ToShortDateString()} - Spot/ID: {car.Name}/{car.CurrentVehicle.Id} - Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Parking: {car.CurrentVehicle.IsParked} - Price: {car.CurrentVehicle.TotalPrice:C}");
                        }
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    if (_other.Count == 0)
                    {
                        Console.WriteLine($"\nAll other spots (0/{_otherMax}) are available in the system.");
                    }
                    else
                    {
                        Console.WriteLine($"\nAvailable parking spots: ( {_other.Count} / {_otherMax - _other.Count} )");
                        foreach (var car in _other)
                        {
                            Console.WriteLine($"Timestamp: {car.CurrentVehicle.ArrivalTime.ToShortDateString()} - Spot/ID: {car.Name}/{car.CurrentVehicle.Id} - Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Parking: {car.CurrentVehicle.IsParked} - Price: {car.CurrentVehicle.TotalPrice:C}");
                        }
                    }
                    Console.ReadKey();
                    break;
                case 5:
                    ParkingSpot? parkingspots = _parkingSpots.Concat(_almindelig).Concat(_handicap).Concat(_bus).Concat(_other).FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                    if (parkingspots == null)
                    {
                        Console.WriteLine("\nLicenseplate not found in the system.");
                    }
                    else
                    {
                        Console.WriteLine($"Timestamp: {parkingspots.CurrentVehicle.ArrivalTime.ToShortDateString()} - Spot/ID: {parkingspots.Name}/{parkingspots.CurrentVehicle.Id} - Licenseplate: {parkingspots.CurrentVehicle.LicensePlate} - Type: {parkingspots.CurrentVehicle.Type} - Parking: {parkingspots.CurrentVehicle.IsParked} - Price: {parkingspots.CurrentVehicle.TotalPrice:C}");
                    }
                    Console.ReadKey();
                    break;
                case 6:
                    GetParkingSpots();
                    break;
                default:
                    break;
            }
        }
        public void GetCarWash()
        {
            if (_carwash.Count == 0)
            {
                Console.WriteLine($"\nAll carwash spots (0/{_carwashMax}) are available in the system.");
            }
            else
            {
                Console.WriteLine($"\nAvailable carwash spots: ( {_carwash.Count} / {_carwashMax - _carwash.Count} )");
                foreach (var car in _carwash)
                {
                    Console.WriteLine($"Timestamp: {car.CurrentVehicle.ArrivalTime.ToShortDateString()} - Spot/ID: {car.Name}/{car.CurrentVehicle.Id} - Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Status} - Underwash: {car.CurrentVehicle.UnderWash} - Price: {car.CurrentVehicle.TotalPrice:C}");
                }
            }
            Console.ReadKey();
        }
        #endregion

        #region Her opretter den en ny bil og tilføjer den til en parkeringsplads
        public void CreateParkingSpace()
        {
            string spotId = "P" + _idCounter++;
            Car car = new(spotId, InputString("\nInput your licenseplate: "), CreateSpotMenu())
            {
                IsParked = true
            };
            switch (car.Type)
            {
                case CarType.Almindelig:
                    _almindelig.Add(new AlmindeligSpot(spotId, _almindeligPrice, car));
                    break;

                case CarType.Handicap:
                    _handicap.Add(new HandicapSpot(spotId, _handicapPrice, car));
                    break;

                case CarType.Bus:
                    _bus.Add(new BusSpot(spotId, _busPrice, car));
                    break;

                case CarType.Other:
                    _other.Add(new OtherSpot(spotId, _otherPrice, car));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Her opretter den en ny bil eller finder en bil i systemet og tilføjer den til en vask
        public async void CreateCarWash()
        {
            if (_carwash.Count < _carwashMax)
            {
                string spotId = "CW" + _idCounter++;
                Car car = new(spotId, InputString("\nInput your licenseplate: "), CreateSpotMenu())
                {
                    UnderWash = true
                };
                _carwash.Add(new StartWash(spotId, _carwashPrice, car));
                await StartOfWash(car);
            }
            else
            {
                Console.WriteLine("\nAll carwash spots are occupied.");
                Console.ReadKey();
            }
        }
        public static async Task StartOfWash(Car car)
        {

            await Task.Delay(15000); // Simuler vaskfase 1
            car.Status = WashStatus.Vasker;
            await Task.Delay(15000); // Simuler vaskfase 2
            car.Status = WashStatus.Skylning;
            await Task.Delay(15000); // Simuler vaskfase 3
            car.Status = WashStatus.Tørring;
            await Task.Delay(15000); // Simuler vaskfase 4
            car.Status = WashStatus.Afsluttet;
            car.UnderWash = false;

            Console.WriteLine($"\nWash completed for the following car: {car.LicensePlate}");
        }
        #endregion

        #region Writeline and readline returning a cartype
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
                        if (_other.Count < _otherMax)
                        {
                            return CarType.Other;
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
        #endregion

        #region Paying for parking or washing
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
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can leave by following:      |");
                Console.WriteLine("| 0 = Go back to main menu         |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|----------------------------------|");
                Console.Write("Please choose an option: ");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        PayForParking();
                        runtime = false;
                        break;
                    case ConsoleKey.D2:
                        PayForCarWash();
                        runtime = false;
                        break;
                    case ConsoleKey.D0:
                        runtime = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void PayForCarWash()
        {
            if (!_carwash.Any())
            {
                Console.WriteLine("\nThere are no cars in the car wash");

            }
            else
            {
                var carwash = _carwash.FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                while (carwash == null)
                {
                    Console.WriteLine("\nLicenseplate not found in the system.");
                    carwash = _carwash.FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                }
                if (carwash.CurrentVehicle.Status != WashStatus.Afsluttet)
                {
                    Console.WriteLine("\nCarwash is not completed yet.");
                    Console.WriteLine($"Car status: {carwash.CurrentVehicle.Status}");

                }
                else
                {
                    _carwash.Remove(carwash);
                    Console.WriteLine($"\nYou have to pay: {carwash.CurrentVehicle.TotalPrice:C}");

                }
            }
            Console.ReadKey();
        }
        public void PayForParking()
        {
            bool runtime = true;
            while (runtime == true)
            {
                Console.Clear();
                Console.WriteLine("|----------------------------------|");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can chose the following:     |");
                Console.WriteLine("| 1 = Pay for normal spot          |");
                Console.WriteLine("| 2 = Pay for handicap spot        |");
                Console.WriteLine("| 3 = Pay for bus spot             |");
                Console.WriteLine("| 4 = Pay for other spot           |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can leave by following:      |");
                Console.WriteLine("| 0 = Go back to main menu         |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|----------------------------------|");
                Console.Write("Please choose an option: ");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        if (!_almindelig.Any())
                        {
                            Console.WriteLine("\nThere are no cars parked in a normal spot");
                            break;
                        }
                        else
                        {
                            var almindelig = _almindelig.FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                            while (almindelig == null)
                            {
                                Console.WriteLine("\nLicenseplate not found in the system.");
                                almindelig = _almindelig.FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                            }
                            _almindelig.Remove(almindelig);
                            Console.WriteLine($"\nYou have to pay: {almindelig.CurrentVehicle.TotalPrice:C}");
                            runtime = false;
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        if (!_handicap.Any())
                        {
                            Console.WriteLine("\nThere are no cars parked in a handicap spot");
                            break;
                        }
                        else
                        {
                            var handicap = _handicap.FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                            while (handicap == null)
                            {
                                Console.WriteLine("\nLicenseplate not found in the system.");
                                handicap = _handicap.FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                            }
                            _handicap.Remove(handicap);
                            Console.WriteLine($"\nYou have to pay: {handicap.CurrentVehicle.TotalPrice:C}");
                            runtime = false;
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        if (!_bus.Any())
                        {
                            Console.WriteLine("\nThere are no cars parked in a bus spot");
                            break;
                        }
                        else
                        {
                            var bus = _bus.FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                            while (bus == null)
                            {
                                Console.WriteLine("\nLicenseplate not found in the system.");
                                bus = _bus.FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                            }
                            _bus.Remove(bus);
                            Console.WriteLine($"\nYou have to pay: {bus.CurrentVehicle.TotalPrice:C}");
                            runtime = false;
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        if (!_other.Any())
                        {
                            Console.WriteLine("\nThere are no cars parked in a other spot");
                            break;
                        }
                        else
                        {
                            var other = _other.FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                            while (other == null)
                            {
                                Console.WriteLine("\nLicenseplate not found in the system.");
                                other = _other.FirstOrDefault(x => x.CurrentVehicle.LicensePlate == InputString("\nInput your licenseplate: "));
                            }
                            _other.Remove(other);
                            Console.WriteLine($"\nYou have to pay: {other.CurrentVehicle.TotalPrice:C}");
                            runtime = false;
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D0:
                        runtime = false;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Her sender den menupunktet tilbage
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
            Console.WriteLine("| 0 = Exit                         |");
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
        public void PrintCars()
        {
            bool runtime = true;
            while (runtime == true)
            {
                Console.Clear();
                Console.WriteLine("|----------------------------------|");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can chose the following:     |");
                Console.WriteLine("| 1 = Almindelig                   |");
                Console.WriteLine("| 2 = Handicap                     |");
                Console.WriteLine("| 3 = Bus                          |");
                Console.WriteLine("| 4 = Other                        |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You see one or all by pressing:  |");
                Console.WriteLine("| 5 = One                          |");
                Console.WriteLine("| 6 = All                          |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can go back by pressing:     |");
                Console.WriteLine("| 0 = Back                         |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|----------------------------------|");
                Console.Write("Please choose an option: ");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        GetSpots(1);
                        break;
                    case ConsoleKey.D2:
                        GetSpots(2);
                        break;
                    case ConsoleKey.D3:
                        GetSpots(3);
                        break;
                    case ConsoleKey.D4:
                        GetSpots(4);
                        break;
                    case ConsoleKey.D5:
                        GetSpots(5);
                        break;
                    case ConsoleKey.D6:
                        GetSpots(6);
                        break;
                    case ConsoleKey.D0:
                        runtime = false;
                        break;
                    default:
                        break;
                }
            }

        }
        #endregion

        #region Her indsætter du de forskellinge inputs med string, int og decimal
        /// <summary>
        /// Prompter the user for input until a non-empty string is provided.
        /// </summary>
        /// <param name="promptMessage">The message to display to the user.</param>
        /// <returns>A non-empty user input string.</returns>
        static string InputString(string promptMessage)
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
        static int InputInt(string promptMessage, string? errorMessage)
        {
            errorMessage ??= "Wrong input";  // If errorMessage is null, use "Wrong input" as the default
            while (true)
            {
                Console.Write(promptMessage);
                if (int.TryParse(Console.ReadLine(), out int result))
                    if (result > 0)
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
        static decimal InputDecimal(string promptMessage, string? errorMessage)
        {
            errorMessage ??= "Wrong input";  // If errorMessage is null, use "Wrong input" as the default
            while (true)
            {
                Console.Write(promptMessage);
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                    if (result > 0)
                        return result;
                Console.WriteLine(errorMessage);
            }
        }
        #endregion
        #endregion
    }
}
