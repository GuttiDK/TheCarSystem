using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Models
{

    public enum WashStatus
    {
        Vasker,
        Skylning,
        Tørring,
        Afsluttet,
    }

    public abstract class CarWash
    {
        private static int _idCounter = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public Car CurrentVehicle { get; set; }
        public WashStatus Status { get; set; }
        public decimal Price { get; set; }

        public CarWash(string name, decimal price, Car car)
        {
            Id = _idCounter++;
            Name = name;
            CurrentVehicle = car;
            Price = price;
        }
    }

    public class StartWash : CarWash
    {
        public StartWash(string name, decimal price, Car car) : base(name, price, car)
        {
            Status = WashStatus.Vasker;
            Price = price;
            car.UnderWash = true;
            car.WashPrice = Price;
            
        }
    }

}
