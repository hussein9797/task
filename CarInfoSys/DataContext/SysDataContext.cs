using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarInfoSys.Models;


namespace CarInfoSys.DataContext
{
    public class SysDataContext : DbContext
    {

        public SysDataContext(DbContextOptions<SysDataContext> options):base(options) {
            
            }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }

        public DbSet<Features> Features { get; set; }
    }
  

}
