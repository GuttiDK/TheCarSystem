using CarSystem.Data;
using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.BLL
{
    public class CarsWash
    {
        private readonly ICarWash _repo;

        public CarsWash(ICarWash repo)
        {
            _repo = repo;
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
