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
using CarSystem.BLL;
using CarSystem.Controllers;

namespace CarSystem.View
{
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        public static void Main()
        {
            var services1 = new ServiceCollection()
            .AddSingleton<ICarParking, CarRepo>()
            .BuildServiceProvider();

            CarParking carParking = new(services1.GetRequiredService<ICarParking>());

            bool runTime = true;
            while (runTime == true)
            {
                carParking.CarSystemMenu();
                try
                {
                    var input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.P:
                            carParking.CreateParkingSpace();
                            break;
                        case ConsoleKey.W:
                            carParking.CreateCarWash();
                            break;
                        case ConsoleKey.S:
                            carParking.PrintCars();
                            break;
                        case ConsoleKey.O:
                            carParking.GetCarWash();
                            break;
                        case ConsoleKey.B:
                            carParking.ChangeMenu();
                            break;
                        case ConsoleKey.R:
                            carParking.Pay();
                            break;
                        case ConsoleKey.D0:
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





    }
}

