﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInfoSys.Repositories
{
   public interface FeatureRepository
    {

        double getDailyFareForCar(carType carType, EngineCapacity engineCapacity);

    }
}
