using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInfoSys.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long customerId { get; set; }

        public string customerFirstName { get; set; }

        public string customerLastName { get; set; }

        public  ICollection<CarRental> carRentals { get; set; }

        public string phoneNumber { get; set; }
    }
}
