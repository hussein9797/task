using CarInfoSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInfoSys.Repositories
{
   public interface CarRentalRepository
    {

        public void save(Car car);
    }
}
