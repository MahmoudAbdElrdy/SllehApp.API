using System;
using System.Collections.Generic;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopCarController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesWorkshopCar _WorkshopCarServices;
        public WorkshopCarController(IServicesWorkshopCar WorkshopCarServices)
        {
            _WorkshopCarServices = WorkshopCarServices;
        }
        #endregion

        #region Post: api/WorkshopCar/SaveWorkshopCar
        [HttpPost]
        [Route("SaveWorkshopCar")]
        public IResponseDTO postWorkshopCar(WorkshopCarVM WorkshopCarVM)
        {
            var depart = _WorkshopCarServices.PostWorkshopCar(WorkshopCarVM);
            return depart;
        }
        #endregion

        #region Put: api/WorkshopCar/UpdateWorkshopCar
        [HttpPut]
        [Route("UpdateWorkshopCarList")]
        public IResponseDTO UpdateWorkshopCarList(List<WorkshopCarVM> WorkshopCarVM)
        {
            var depart = _WorkshopCarServices.EditWorkshopCar(WorkshopCarVM);
            return depart;
        }
        [HttpPut]
        [Route("UpdateWorkshopCar")]
        public IResponseDTO UpdateWorkshopCar(WorkshopCarVM WorkshopCarVM)
        {
            var depart = _WorkshopCarServices.EditWorkshopCar(WorkshopCarVM);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopCar/GetAllWorkshopCar
        [HttpGet]
        [Route("GetAllWorkshopCar")]
        public IResponseDTO GetAllWorkshopCar()
        {
            var depart = _WorkshopCarServices.GetAllWorkshopCar();
            return depart;
        }
        [HttpGet]
        [Route("GetAllByWorkShopId")]
        public IResponseDTO GetAllByWorkShopId(Guid guid)
        {
            var depart = _WorkshopCarServices.GetAllWorkshopCar(guid);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopCar/GetWorkshopCarById
        [HttpGet]
        [Route("GetWorkshopCarById")]
        public IResponseDTO GetById(Guid id)
        {
            var depart = _WorkshopCarServices.GetByIDWorkshopCar(id);
            return depart;
        }
        #endregion

        #region Delete: api/WorkshopCar/RemoveWorkshopCar
        [HttpDelete]
        [Route("RemoveWorkshopCar")]
        public IResponseDTO RemoveWorkshopCar(WorkshopCarVM WorkshopCarVM)
        {
            var depart = _WorkshopCarServices.DeleteWorkshopCar(WorkshopCarVM);
            return depart;
        }
        #endregion
    }
}