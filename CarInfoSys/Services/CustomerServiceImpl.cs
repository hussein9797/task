using CarInfoSys.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInfoSys.Services
{
    public class CustomerServiceImpl : CustomerService
    {

        private CustomerRepository customerRepository;

        public CustomerServiceImpl(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
    }
}
