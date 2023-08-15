using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInfoSys.Dto.requests;
using CarInfoSys.Models;

namespace CarInfoSys.Services
{
    public interface CarService
    {
        void addCar(addCarRequest addCarRequest);
        void deleteCar(long carId);

        IEnumerable<Car> ListAllCars();

        IEnumerable<Car> ListAllCarsSortedBy(string sortField, bool ascendingOrder = true);
        IEnumerable<Car> ListAlLCarsPaginated(int page, int pageSize);

        


        void updateCar(updateCarRequest updateCarRequest);

        IEnumerable<Car> SearchCars(CarSearchRequest carSearchRequest);
        IEnumerable<Car> SearchCarsCached(CarSearchRequest carSearchRequest);
    }
}
