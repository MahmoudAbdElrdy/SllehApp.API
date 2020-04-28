using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesCar _CarServices;
        public CarController(IServicesCar CarServices)
        {
            _CarServices = CarServices;
        }
        #endregion

        #region Post: api/Car/SaveCar
        [HttpPost]
        [Route("SaveCar")]
        public IResponseDTO postCar(CarVM CarVM)
        {
            var depart = _CarServices.PostCar(CarVM);
            return depart;
        }
        #endregion

        #region Put: api/Car/UpdateCar
        [HttpPut]
        [Route("UpdateCar")]
        public IResponseDTO UpdateCar(CarVM CarVM)
        {
            var depart = _CarServices.EditCar(CarVM);
            return depart;
        }
        #endregion

        #region Get: api/Car/GetAllCar
        [HttpGet]
        [Route("GetAllCar")]
        public IResponseDTO GetAllCar()
        {
            var depart = _CarServices.GetAllCar();
            return depart;
        }
        #endregion

        #region Get: api/Car/GetCarById
        [HttpGet]
        [Route("GetCarById")]
        public IResponseDTO GetById(Guid ?id)
        {
            var depart = _CarServices.GetByIDCar(id);
            return depart;
        }
        #endregion

        #region Delete: api/Car/RemoveCar
        [HttpDelete]
        [Route("RemoveCar")]
        public IResponseDTO RemoveCar(CarVM CarVM)
        {
            var depart = _CarServices.DeleteCar(CarVM);
            return depart;
        }
        #endregion
    }
}