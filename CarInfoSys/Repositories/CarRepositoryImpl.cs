using CarInfoSys.DataContext;
using CarInfoSys.Dto.requests;
using CarInfoSys.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarInfoSys.Repositories
{
    public class CarRepositoryImpl : CarRepository
    {

        private SysDataContext dataContext;

        public CarRepositoryImpl(SysDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void deleteCar(long vechileId)
        {

            Car carToBeDeleted = dataContext.Cars.Find(vechileId);
            dataContext.Cars.Remove(carToBeDeleted);
            dataContext.SaveChanges();
        }

        public IEnumerable<Car> findAll()
        {
            return dataContext.Cars.OrderBy(car => car.viechleId).ToList();

        }

        public IEnumerable<Car> findAllPaginated(int page, int pageSize)
        {
            try
            {
                int skipCount = (page - 1) * pageSize;

                return dataContext.Cars
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<Car> findAllSortedBy<TSort>(Expression<Func<Car, TSort>> sortExpression, bool ascendingOrder = true)
        {
            if (ascendingOrder)
                return dataContext.Cars.OrderBy(sortExpression);
            else
                return dataContext.Cars.OrderByDescending(sortExpression);
        }

        public Car findById(long viechleId)
        {
            Car carfound = dataContext.Cars.Find(viechleId);
            if (carfound != null)
                return carfound;

            else
                throw new KeyNotFoundException("car dose not exist");

        }

        public void save(Car car)
        {
            try
            {
                dataContext.Cars.Add(car);
                dataContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public IEnumerable<Car> searchCars(CarSearchRequest carSearchRequest)
        {
            var query = dataContext.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(carSearchRequest.carType))
            {
                query = query.Where(car => car.carType == carSearchRequest.carType.ToCarType());
            }

            if (!string.IsNullOrEmpty(carSearchRequest.engineCapacity))
            {
                query = query.Where(car => car.egnineCpacity == carSearchRequest.engineCapacity.ToEngineCapacity());
            }

            if (!string.IsNullOrEmpty(carSearchRequest.color))
            {
                query = query.Where(car => car.color == carSearchRequest.color);
            }

            if (carSearchRequest.rented.HasValue)
            {
                query = query.Where(car => car.rented == carSearchRequest.rented.Value);
            }

            return query.ToList();
        }

        public IEnumerable<Car> searchCars(IEnumerable<Car> cars, CarSearchRequest carSearchRequest)
        {
            var query = cars.AsQueryable();

            if (!string.IsNullOrEmpty(carSearchRequest.carType))
            {
                query = query.Where(car => car.carType == carSearchRequest.carType.ToCarType());
            }

            if (!string.IsNullOrEmpty(carSearchRequest.engineCapacity))
            {
                query = query.Where(car => car.egnineCpacity == carSearchRequest.engineCapacity.ToEngineCapacity());
            }

            if (!string.IsNullOrEmpty(carSearchRequest.color))
            {
                query = query.Where(car => car.color == carSearchRequest.color);
            }

            if (carSearchRequest.rented.HasValue)
            {
                query = query.Where(car => car.rented == carSearchRequest.rented.Value);
            }

            return query.ToList();

        }

        public void updateCar(Car updatedCar)
        {
            dataContext.Entry(updatedCar).State = EntityState.Modified;
            dataContext.SaveChanges();
        }
    }
}
