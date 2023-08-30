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
        Nødstop,
        Fejl,
        KlarTilNæste
    }

    public abstract class CarWash 
    {
        private static int _idCounter = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public Car CurrentVehicle { get; set; }
        public decimal Price { get; set; }
        public WashStatus Status { get; set; }

        public CarWash(string name, Car car)
        {
            Id = _idCounter++;
            Name = name;
            CurrentVehicle = car;
        }
    }

    public class StartWash : CarWash
    {
        public StartWash(string name, Car car) : base(name, car)
        {
            Price = 50;
            car.WashPrice = Price;
            car.IsParked = false;
            car.UnderWash = true;
            Status = WashStatus.Vasker;
        }
    }

}
