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




        public ParkingSpot(string name, Car car)
        {
            Id = _idCounter++;
            Name = name;
            CurrentVehicle = car;
        }
    }

    public class AlmindeligSpot : ParkingSpot
    {
        public AlmindeligSpot(string name, Car car) : base(name, car)
        {
            Type = ParkingType.Almindelig;
            Price = 50;
            IsOccupied = true;
            car.ParkingPrice = Price;
        }
    }

    public class HandicapSpot : ParkingSpot
    {
        public HandicapSpot(string name, Car car) : base(name, car)
        {
            Type = ParkingType.Handicap;
            Price = 150;
            IsOccupied = true;
            car.ParkingPrice = Price;
        }
    }

    public class BusSpot : ParkingSpot
    {
        public BusSpot(string name, Car car) : base(name, car)
        {
            Type = ParkingType.Bus;
            Price = 250;
            IsOccupied = true;
            car.ParkingPrice = Price;
        }
    }

    public class ElseSpot : ParkingSpot
    {
        public ElseSpot(string name, Car car) : base(name, car)
        {
            Type = ParkingType.Else;
            Price = 100;
            IsOccupied = true;
            car.ParkingPrice = Price;
        }
    }
}
