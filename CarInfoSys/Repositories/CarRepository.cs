using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarInfoSys.Dto.requests;
using CarInfoSys.Models;

namespace CarInfoSys.Repositories
{
    public interface CarRepository
    {
        void save(Car newCar);

        IEnumerable<Car> findAll();
        IEnumerable<Car> findAllSortedBy<TSort>(Expression<Func<Car, TSort>> sortExpression, bool ascendingOrder = true);


        Car findById(long viechleId);

        void updateCar(Car updatedCar);

        void deleteCar(long vechileId);
        IEnumerable<Car> findAllPaginated(int page, int pageSize);
        IEnumerable<Car> searchCars(CarSearchRequest carSearchRequest);
         IEnumerable<Car> searchCars(IEnumerable<Car> cars, CarSearchRequest carSearchRequest);

    }
}
