using CarInfoSys.Dto.requests;
using CarInfoSys.Models;
using CarInfoSys.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInfoSys.Services
{
    public class CarRentalServiceImpl : CarRentalService
    {

        private CarRentalRepository carRentalRepository;

        public CarRentalServiceImpl(CarRentalRepository carRentalRepository)
        {
            this.carRentalRepository = carRentalRepository;
        }

       
    }
}
