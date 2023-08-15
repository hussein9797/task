using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInfoSys.Models
{
    public class Car
    {




        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public  long viechleId { get; set; }

        public carType carType { get; set; }

        public EngineCapacity egnineCpacity { get; set; }

        public string color { get; set; }

        public double dailyFare { get; set; }

        public ICollection<CarRental> carRentals { get; set; }

        public bool rented { get; set; }
        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Car()
        {
            createdAt = DateTime.UtcNow;
            updatedAt = DateTime.UtcNow;
        }





    }
}
