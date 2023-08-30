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
        public int Id { get; set; }
        public string Name { get; set; }
        public Car CurrentVehicle { get; set; }
        public decimal Price { get; set; }
        public List<Wash> ActiveWash { get; set; } = new List<Wash>();

    public CarWash(int id, string name, Car car)
        {
            Id = id;
            Name = name;
            CurrentVehicle = car;
        }
    }


    public class Wash
    {
        public Car CurrentVehicle { get; set; }
        public WashStatus Status { get; set; }

    public Wash(Car currentVehicle, WashStatus status)
        {
            CurrentVehicle = currentVehicle;
            Status = status;
        }
    }

}
