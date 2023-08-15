using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInfoSys.Dto.requests;
using CarInfoSys.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarInfoSys.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private CarService carService;

        public CarsController(CarService carService)
        {
            this.carService = carService;
        }





        [HttpGet]
        [Route("/cars")]
        public IActionResult getAll()
        {
            try
            {
                
                return Ok(carService.ListAllCars());
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
                throw e;

            }


        }
        [HttpGet]
        [Route("/cars_sorted")]
        public IActionResult getAllSortedBy([FromQuery] string sortField, [FromQuery] bool asceding=true)
        {
            try
            {

                return Ok(carService.ListAllCarsSortedBy(sortField,asceding));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
                throw e;

            }


        }

        [HttpGet]
        [Route("/cars_paginated")]
        public IActionResult getAllPaginated([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {

                return Ok(carService.ListAlLCarsPaginated(page, pageSize));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
                throw e;

            }


        }

        [HttpGet]
        [Route("/cars/search")]
        public IActionResult SearchCars( CarSearchRequest carSearchRequest)
        {
            try
            {
                var cars = carService.SearchCars(carSearchRequest);
                return Ok(cars);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpGet]
        [Route("/cars/search/cache")]
        public IActionResult SearchCacheCars(CarSearchRequest carSearchRequest)
        {
            try
            {
                var cars = carService.SearchCarsCached(carSearchRequest);
                return Ok(cars);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }






        [HttpPost]
        [Route("/add_car")]
        public IActionResult addCar(addCarRequest addCarRequest)
        {
            try
            {
                carService.addCar(addCarRequest);
                return Ok("Created Succssfully");
            }
            catch (Exception e)
            {
                return Conflict(e.Message); 
                throw e;
               
            }
           

        }

        [HttpPut]
        [Route("/update_car")]
        public IActionResult update(updateCarRequest updateCar)
        {
            try
            {
                carService.updateCar(updateCar);
                return Ok("updated Succssfully");
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
                throw e;

            }


        }


        [Route("/delete_car")]
        [HttpDelete]
     
        public IActionResult deleteCar([FromQuery]long viechleId)
        {
            try
            {
                carService.deleteCar(viechleId);
                return Ok("Deleted Succssfully");
            }
            catch (Exception e)
            {
              
                return Conflict(e.Message);
                throw e;

            }


        }






    }
}