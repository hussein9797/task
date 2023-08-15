using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CarInfoSys.Models
{
    public class Features
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long featureId { get; set; }

        public carType carType { get; set; }

        public EngineCapacity engineCapacity { get; set; }


        public bool withDriver { get; set; }

        public double charge;


    }
}
