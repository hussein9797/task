using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInfoSys.Models
{
    public class CarRental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public long rentalId { get; set; }

        public long viechleId { get; set; }

        public long customerId { get; set; }
        public long? dirverId { get; set; }

        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public Driver Driver { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }


        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }
    }
}
