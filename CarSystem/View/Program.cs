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
                carParking.CarSystemMenu();
                try
                {
                    var input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.P:
                            carParking.CreateParkingSpace(new Car(carParking.InputString("\nInput your licenseplate: "), carParking.CreateSpotMenu()));
                            break;
                        case ConsoleKey.S:
                            PrintCars(carParking);
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

            if (carParking.GetAlmindeligSpot().Count == 0)
            {
                Console.WriteLine("\nThere are no cars in the parking lot");
            }
            else
            {
                Console.WriteLine("\nCars in the parking lot:");
                foreach (var car in carParking.GetAlmindeligSpot())
                {
                    Console.WriteLine($"Licenseplate: {car.CurrentVehicle.LicensePlate} - Type: {car.CurrentVehicle.Type} - Price: {car.CurrentVehicle.TotalPrice} - {car.Price} - {car.Id} - {car.CurrentVehicle.Id}");
                }
            }
        }


    }
}

