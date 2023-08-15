using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInfoSys.Models
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long dirverId { get; set; }

        public string driverName { get; set; }

        public string licence { get; set; }

        public  ICollection<CarRental> carRentals { get; set; }


        public string phoneNamber { get; set; }
    }
}
