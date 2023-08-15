using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInfoSys.DataContext;
using CarInfoSys.Models;

namespace CarInfoSys.Repositories
{
    public class CarRentalRepositoryImpl : CarRentalRepository
    {

        private SysDataContext dataContext;

        public CarRentalRepositoryImpl(SysDataContext dataContext)
        {
            this.dataContext = dataContext;
            
        }

        public void save(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
