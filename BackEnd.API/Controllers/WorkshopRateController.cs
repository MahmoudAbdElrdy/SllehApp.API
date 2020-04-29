using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopRateController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesWorkshopRate _WorkshopRateServices;
        public WorkshopRateController(IServicesWorkshopRate WorkshopRateServices)
        {
            _WorkshopRateServices = WorkshopRateServices;
        }
        #endregion

        #region Post: api/WorkshopRate/SaveWorkshopRate
        [HttpPost]
        [Route("SaveWorkshopRate")]
        public IResponseDTO postWorkshopRate(WorkshopRateVM WorkshopRateVM)
        {
            var depart = _WorkshopRateServices.PostWorkshopRate(WorkshopRateVM);
            return depart;
        }
        #endregion

        #region Put: api/WorkshopRate/UpdateWorkshopRate
        [HttpPut]
        [Route("UpdateWorkshopRate")]
        public IResponseDTO UpdateWorkshopRate(WorkshopRateVM WorkshopRateVM)
        {
            var depart = _WorkshopRateServices.EditWorkshopRate(WorkshopRateVM);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopRate/GetAllWorkshopRate
        [HttpGet]
        [Route("GetAllWorkshopRate")]
        public IResponseDTO GetAllWorkshopRate()
        {
            var depart = _WorkshopRateServices.GetAllWorkshopRate();
            return depart;
        }
        #endregion

        #region Get: api/WorkshopRate/GetWorkshopRateById
        [HttpGet]
        [Route("GetWorkshopRateById")]
        public IResponseDTO GetById(object id)
        {
            var depart = _WorkshopRateServices.GetByIDWorkshopRate(id);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopRate/GetByCustomerId
        [HttpGet]
        [Route("GetByCustomerId")]
        public IResponseDTO GetByCustomerId(Guid? id)
        {
            var depart = _WorkshopRateServices.GetByCustomerId(id);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopRate/GetByWorkshopId
        [HttpGet]
        [Route("GetByWorkshopId")]
        public IResponseDTO GetByWorkshopId(Guid? id)
        {
            var depart = _WorkshopRateServices.GetByWorkshopId(id);
            return depart;
        }
        #endregion

        #region Delete: api/WorkshopRate/RemoveWorkshopRate
        [HttpDelete]
        [Route("RemoveWorkshopRate")]
        public IResponseDTO RemoveWorkshopRate(WorkshopRateVM WorkshopRateVM)
        {
            var depart = _WorkshopRateServices.DeleteWorkshopRate(WorkshopRateVM);
            return depart;
        }
        #endregion
    }
}