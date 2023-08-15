using CarInfoSys.Dto.requests;
using CarInfoSys.Models;
using CarInfoSys.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarInfoSys.Services
{
    public class CarServiceImpl : CarService
    {

        private CarRepository carRepository;
        private readonly IMemoryCache carcache;

        public CarServiceImpl(CarRepository carRepository, IMemoryCache carcache)
        {
            this.carRepository = carRepository;
            this.carcache = carcache;
        }


        public void addCar(addCarRequest addCarRequest)
        {

            try
            {


                Car newCar = new Car
                {
                    carType = addCarRequest.type.ToCarType(),
                    color = addCarRequest.color,
                    egnineCpacity = addCarRequest.egnineCpacity.ToEngineCapacity(),
                    dailyFare = addCarRequest.dailyFare   
                };

                carRepository.save(newCar);


            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public void deleteCar(long viechleId)
        {
            try
            {

                carRepository.deleteCar(viechleId);



            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<Car> ListAllCars()
        {
            return carRepository.findAll();
        }

        public IEnumerable<Car> ListAlLCarsPaginated(int page, int pageSize)
        {
             return carRepository.findAllPaginated(page, pageSize);
        }

        public IEnumerable<Car> ListAllCarsSortedBy(string sortField, bool ascendingOrder = true)
        {

            var sortExpression = CreateSortExpression<Car>(sortField);
            if (sortExpression == null)
            {
              
            }
            return carRepository.findAllSortedBy(sortExpression, ascendingOrder);
        }

        public IEnumerable<Car> SearchCars(CarSearchRequest carSearchRequest)
        {
            return carRepository.searchCars(carSearchRequest);
        }
        public IEnumerable<Car> SearchCars(IEnumerable<Car> cars, CarSearchRequest carSearchRequest)
        {
            return carRepository.searchCars(cars,carSearchRequest);
        }

        public void updateCar(updateCarRequest updateCarRequest)
        {
            try
            {

                Car carToBedUpdated = carRepository.findById(updateCarRequest.viechleId);

                carToBedUpdated.carType = updateCarRequest.carType.ToCarType();
                carToBedUpdated.color = updateCarRequest.color;
                carToBedUpdated.egnineCpacity = updateCarRequest.egnineCpacity.ToEngineCapacity();
                carToBedUpdated.rented = updateCarRequest.rented;
                carToBedUpdated.dailyFare = updateCarRequest.dailyFare;
                carToBedUpdated.updatedAt = DateTime.Now;

                carRepository.updateCar(carToBedUpdated);

            }
            catch (Exception e)
            {

                throw e;
            }



    

           
        }




        private Expression<Func<Car, object>> CreateSortExpression<T>(string sortField)
        {
            var parameter = Expression.Parameter(typeof(Car), "car");
            var property = Expression.Property(parameter, sortField);

           
            var convertedProperty = Expression.Convert(property, typeof(object));

            var lambda = Expression.Lambda<Func<Car, object>>(convertedProperty, parameter);
            return lambda;
        }

        public IEnumerable<Car> SearchCarsCached(CarSearchRequest carSearchRequest)
        {
            if (!carcache.TryGetValue("cachedCars", out _))
            {
                var cachedCarss = ListAllCars();
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Cache for 10 minutes
                };
                carcache.Set("cachedCars", cachedCarss, cacheEntryOptions);
            }

            if (carcache.TryGetValue("cachedCars", out IEnumerable<Car> cachedCars))
            {
                var filteredCars = SearchCars(cachedCars, carSearchRequest);
                return filteredCars;
            }

            
            return ListAllCars();
        }

    }

}
