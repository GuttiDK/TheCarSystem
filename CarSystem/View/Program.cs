﻿using CarSystem.Data;
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
        public static void Main(string[] args)
        {
            var services1 = new ServiceCollection()
            .AddSingleton<ICarParking, CarMethods>()
            .BuildServiceProvider();

            var services2 = new ServiceCollection()
            .AddSingleton<ICarWash, CarMethods>()
            .BuildServiceProvider();

            CarParking carParking = new CarParking(services1.GetRequiredService<ICarParking>());
            CarsWash carsWash = new CarsWash(services2.GetRequiredService<ICarWash>());

            bool runTime = true;
            while (runTime == true)
            {
                carParking.CarSystemMenu();
                carsWash.ToString();
                try
                {
                    var input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.P:
                            carParking.CreateParkingSpace();
                            break;
                        case ConsoleKey.W:
                            break;
                        case ConsoleKey.S:
                            PrintCars(carParking);
                            break;
                        case ConsoleKey.O:
                            break;
                        case ConsoleKey.B:
                            break;
                        case ConsoleKey.R:
                            carParking.Pay();
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


        public static void PrintCars(CarParking carParking)
        {
            bool runtime = true;
            while (runtime == true)
            {
                Console.Clear();
                Console.WriteLine("|----------------------------------|");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can chose the following:     |");
                Console.WriteLine("| a = Almindelig                   |");
                Console.WriteLine("| h = Handicap                     |");
                Console.WriteLine("| b = Bus                          |");
                Console.WriteLine("| e = Else                         |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can see all by pressing:     |");
                Console.WriteLine("| 5 = All                          |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("| You can go back by pressing:     |");
                Console.WriteLine("| 0 = Back                         |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|----------------------------------|");
                Console.Write("Please choose an option: ");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("\nCar in the parking lot:");
                        carParking.GetAlmindeligSpot();
                        break;
                    case ConsoleKey.H:
                        Console.WriteLine("\nCars in the parking lot:");
                        carParking.GetHandicapSpot();
                        break;
                    case ConsoleKey.B:
                        Console.WriteLine("\nCars in the parking lot:");
                        carParking.GetBusSpot();
                        break;
                    case ConsoleKey.E:
                        Console.WriteLine("\nCars in the parking lot:");
                        carParking.GetElseSpot();
                        break;
                    case ConsoleKey.D5:
                        carParking.ParkingSpots();
                        break;
                    case ConsoleKey.D0:
                        runtime = false;
                        break;
                    default:
                        break;
                }
            }

        }


    }
}

