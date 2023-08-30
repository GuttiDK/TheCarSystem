using CarSystem.Data;
using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.BLL
{
    public class CarParking
    {
        private readonly ICarParking _repo;

        public CarParking(ICarParking repo)
        {
            _repo = repo;
        }


        public void CarSystemMenu()
        {
            _repo.CarSystemMenu();
        }

        public void Pay()
        {
            _repo.Pay();
        }

        public void CreateParkingSpace()
        {
            _repo.CreateParkingSpace();
        }



        /// <summary>
        /// Tager imod parkeringspladser
        /// </summary>
        public void GetAlmindeligSpot()
        {
            _repo.GetAlmindeligSpot();
        }
        public void GetHandicapSpot()
        {
            _repo.GetHandicapSpot();
        }
        public void GetBusSpot()
        {
            _repo.GetBusSpot();
        }
        public void GetElseSpot()
        {
            _repo.GetElseSpot();
        }
        public void ParkingSpots()
        {
            _repo.GetParkingSpots();
        }


        /// <summary>
        /// Inputs a value and returns it
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string InputString(string message)
        {
            return _repo.InputString(message);
        }
        public int InputInt(string text, string error)
        {
            return _repo.InputInt(text, error);
        }
        public decimal InputDecimal(string text, string error)
        {
            return _repo.InputDecimal(text, error);
        }

    }
}
