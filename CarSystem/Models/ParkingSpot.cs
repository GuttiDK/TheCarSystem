using CarSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Models
{
    public enum ParkingType
    {
        Almindelig,
        Handicap,
        Bus,
        Else
    }

    public abstract class ParkingSpot
    {
        private static int _idCounter = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public ParkingType Type { get; set; }
        public bool IsOccupied { get; set; } = false;
        public decimal Price { get; set; }
        public Car CurrentVehicle { get; set; }




        public ParkingSpot(string name, decimal price, Car car)
        {
            Id = _idCounter++;
            Name = name;
            CurrentVehicle = car;
            Price = price;
        }
    }

    public class AlmindeligSpot : ParkingSpot
    {
        public AlmindeligSpot(string name, decimal price, Car car) : base(name, price, car)
        {
            Type = ParkingType.Almindelig;
            Price = price;
            IsOccupied = true;
            car.ParkingPrice = Price;
        }
    }

    public class HandicapSpot : ParkingSpot
    {
        public HandicapSpot(string name, decimal price, Car car) : base(name, price, car)
        {
            Type = ParkingType.Handicap;
            Price = price;
            IsOccupied = true;
            car.ParkingPrice = Price;
        }
    }

    public class BusSpot : ParkingSpot
    {
        public BusSpot(string name, decimal price, Car car) : base(name, price, car)
        {
            Type = ParkingType.Bus;
            Price = 250;
            IsOccupied = true;
            car.ParkingPrice = Price;
        }
    }

    public class ElseSpot : ParkingSpot
    {
        public ElseSpot(string name, decimal price, Car car) : base(name, price, car)
        {
            Type = ParkingType.Else;
            Price = price;
            IsOccupied = true;
            car.ParkingPrice = Price;
        }
    }
}
