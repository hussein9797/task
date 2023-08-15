using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInfoSys.Repositories;

namespace CarInfoSys.Services
{
    public class DriverServiceImpl : DriverService
    {
        private DriverRepository driverRepository;

        public DriverServiceImpl(DriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }
    }
}