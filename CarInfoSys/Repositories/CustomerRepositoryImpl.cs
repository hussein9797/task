using CarInfoSys.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInfoSys.Repositories
{
    public class CustomerRepositoryImpl : CustomerRepository
    {
        private SysDataContext dataContext;

        public CustomerRepositoryImpl(SysDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
