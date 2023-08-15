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
        public DbSet<Car> Customers { get; set; }
        public DbSet<Car> Drivers { get; set; }
        public DbSet<Car> CarRentals { get; set; }

        public DbSet<Features> Features { get; set; }
    }
  

}
