using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInfoSys.Dto.requests
{
    public class CarSearchRequest
    {
        public string carType { get; set; }
        public string engineCapacity { get; set; }
        public string color { get; set; }
        public bool? rented { get; set; }
    }
}
