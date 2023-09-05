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


        /// <summary>
        /// Prints the menu
        /// </summary>
        public void CarSystemMenu()
        {
            _repo.CarSystemMenu();
        }


        /// <summary>
        /// Changes the prices
        /// </summary>
        public void ChangeMenu()
        {
            _repo.ChangeMenu();
        }

        /// <summary>
        /// Sorts the payment
        /// </summary>
        public void Pay()
        {
            _repo.Pay();
        }

        /// <summary>
        /// Creates parking spots
        /// </summary>
        public void CreateParkingSpace()
        {
            _repo.CreateParkingSpace();
        }



        /// <summary>
        /// Tager imod parkeringspladser
        /// </summary>
        public void PrintCars()
        {
            _repo.PrintCars();
        }


        public void CreateCarWash()
        {
            _repo.CreateCarWash();
        }

        public void GetCarWash()
        {
            _repo.GetCarWash();
        }
    }
}
