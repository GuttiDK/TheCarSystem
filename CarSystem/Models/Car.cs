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
        Free
    }

    public class Car
    {
        private static int _idCounter = 0;
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public CarType Type { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool UnderWash { get; set; }
        public bool IsParked { get; set; }
        public decimal WashPrice { get; set; }
        public decimal ParkingPrice { get; set; }
        public decimal TotalPrice { get { return WashPrice + ParkingPrice; } }


        public Car(string licensePlate, CarType type)
        {
            Id = _idCounter++;
            LicensePlate = licensePlate;
            Type = type;
            ArrivalTime = DateTime.Now;
            UnderWash = false;
            IsParked = false;
        }
    }
}
