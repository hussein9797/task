using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInfoSys.Dto.requests
{
    public class addCarRequest
    {

        public string type { get; set; }

        public string egnineCpacity { get; set; }

        public string color { get; set; }

        public double dailyFare { get; set; }

        
    }
}
