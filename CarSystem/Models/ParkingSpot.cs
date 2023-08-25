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
        Free
    }

    public abstract class ParkingSpot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ParkingType Type { get; set; }
        public bool IsOccupied { get; set; } = false;
        public int Price { get; set; }
        public Car CurrentVehicle { get; set; }
        public int NumberOfParkingLots { get; set; }




        public ParkingSpot(int id, string name, Car car)
        {
            Id = id;
            Name = name;
            CurrentVehicle = car;
            NumberOfParkingLots = 20;
        }
    }

    public class AlmindeligSpot : ParkingSpot
    {
        public AlmindeligSpot(int id, string name, Car car) : base(id, name, car)
        {
            Type = ParkingType.Almindelig;
            Price = 50;
        }
    }

    public class HandicapSpot : ParkingSpot
    {
        public HandicapSpot(int id, string name, Car car) : base(id, name, car)
        {
            Type = ParkingType.Handicap;
            Price = 150;
        }
    }

    public class BusSpot : ParkingSpot
    {
        public BusSpot(int id, string name, Car car) : base(id, name, car)
        {
            Type = ParkingType.Bus;
            Price = 250;
        }
    }

    public class FreeSpot : ParkingSpot
    {
        public FreeSpot(int id, string name, Car car) : base(id, name, car)
        {
            Type = ParkingType.Free;
            Price = 0;
        }
    }
}
