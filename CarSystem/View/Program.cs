using CarSystem.Data;
using Microsoft.Extensions.DependencyInjection;
using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarSystem.View
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection()
            .AddSingleton<ICarParking, CarMethods>()
            .BuildServiceProvider();

            CarParking carParking = new CarParking(services.GetRequiredService<ICarParking>());

            bool runTime = true;
            while (runTime == true)
            {
                CarSystemMenu();
                try
                {
                    var input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.P:
                            carParking.CreateParkingSpace(new Car(InputString("Input your licenseplate: "), CreateSpotMenu()));
                            break;
                        case ConsoleKey.S:
                            Console.WriteLine("You have " + carParking.GetAlmindeligSpot().Count() + " parking spots left");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.X:
                            runTime = false;
                            break;
                        default:
                            Console.WriteLine("Wrong input");
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }





        /// <summary>
        /// Car
        public static void CarSystemMenu()
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
        /// Input vaules
        /// </summary>

        /// <summary>
        /// Writeline and readline returning string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        static string InputString(string text)
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
        static int InputInt(string text, string error)
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
        static decimal InputDecimal(string text, string error)
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

        /// <summary>
        /// Writeline and readline returning a accounttype
        /// </summary>
        /// <param name="text"></param>
        /// <returns>list</returns>
        public static CarType CreateSpotMenu()
        {
            do
            {
                switch (InputInt("1 = Almindelig\n2 = Handicap\n3 = Bus \n4 = Free\nInsert accounttype: ", "Wrong input"))
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

    }
}

