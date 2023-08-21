using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.View
{
    class CarSystem
    {
        public static void CarSystems()
        {
            bool runTime = true;
            while (runTime == true)
            {
                CarSystemMenu();
                try
                {
                    switch (InputString("Insert here: "))
                    {
                        case "1":
                            CarParking.CarParking();
                            break;
                        case "2":
                            CarWash.CarWash();
                            break;
                        case "x":
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

        public static void CarSystemMenu()
        {
            Console.WriteLine(" ----------------------------------");
            Console.WriteLine("| You can chose the following:     |");
            Console.WriteLine("| p = Car Parking                  |");
            Console.WriteLine("| w = Car Wash                     |");
            Console.WriteLine("| ");
            Console.WriteLine("| x = Exit                         |");
            Console.WriteLine(" ----------------------------------");
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
        static int InputInt(string text)
        {
            int value;
            while (true)
            {
                Console.Write(text);
                try
                {
                    return value = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Writeline and readline returning only demical
        /// </summary>
        /// <param name="text"></param>
        /// <returns>demical</returns>
        static decimal InputDecimal(string text)
        {
            decimal value;
            while (true)
            {
                Console.Write(text);
                try
                {
                    return value = Convert.ToDecimal(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}
