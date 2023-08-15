using CarInfoSys.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInfoSys.Models;
namespace CarInfoSys.Repositories
{
    public class FeatureRepositoryImpl : FeatureRepository
    {
        private SysDataContext sysDataContext;

        public FeatureRepositoryImpl(SysDataContext sysDataContext)
        {
            this.sysDataContext = sysDataContext;
        }

        public double getDailyFareForCar(carType carType, EngineCapacity engineCapacity)
        {
       
         
            
            throw new NotImplementedException();
        }
    }
}
