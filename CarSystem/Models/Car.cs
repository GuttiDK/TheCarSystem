using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Models
{ 

    public enum CarType
    {
        Almindelig,
        Handicap,
        Bus,
        Other
    }

    public class Car
    {
        private static int _idCounter = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicensePlate { get; set; }
        public CarType Type { get; set; }
        public WashStatus Status { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool UnderWash { get; set; }
        public bool IsParked { get; set; }
        public decimal WashPrice { get; set; }
        public decimal ParkingPrice { get; set; }
        public decimal TotalPrice { get { return WashPrice + ParkingPrice; } }


        public Car(string name, string licensePlate, CarType type)
        {
            Name = name;
            Id = _idCounter++;
            LicensePlate = licensePlate;
            Type = type;
            ArrivalTime = DateTime.Now;
            UnderWash = false;
            IsParked = false;
        }
    }
}
