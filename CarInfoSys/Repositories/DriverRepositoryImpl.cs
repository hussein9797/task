using CarInfoSys.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInfoSys.Repositories
{
     public class DriverRepositoryImpl : DriverRepository
    {
        private SysDataContext dataContext;

        public DriverRepositoryImpl(SysDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
