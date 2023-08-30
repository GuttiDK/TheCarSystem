using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Data
{
    public interface ICarParking
    { 
        // Create parking spots
        public void CreateParkingSpace();

        // Menu
        public void CarSystemMenu();

        // Pay
        public void Pay();

        // Get parking spots
        public void GetAlmindeligSpot();
        public void GetHandicapSpot();
        public void GetBusSpot();
        public void GetElseSpot();
        public void GetParkingSpots();

        // Find cars


        // Input
        public string InputString(string message);
        public int InputInt(string text, string error);
        public decimal InputDecimal(string text, string error);
    }
}
