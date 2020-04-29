using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopWorkTimeController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesWorkshopWorkTime _WorkshopWorkTimeServices;
        public WorkshopWorkTimeController(IServicesWorkshopWorkTime WorkshopWorkTimeServices)
        {
            _WorkshopWorkTimeServices = WorkshopWorkTimeServices;
        }
        #endregion

        #region Post: api/WorkshopWorkTime/SaveWorkshopWorkTime
        [HttpPost]
        [Route("SaveWorkshopWorkTime")]
        public IResponseDTO postWorkshopWorkTime(WorkshopWorkTimeVM WorkshopWorkTimeVM)
        {
            var depart = _WorkshopWorkTimeServices.PostWorkshopWorkTime(WorkshopWorkTimeVM);
            return depart;
        }
        #endregion

        #region Put: api/WorkshopWorkTime/UpdateWorkshopWorkTime
        [HttpPut]
        [Route("UpdateWorkshopWorkTime")]
        public IResponseDTO UpdateWorkshopWorkTime(WorkshopWorkTimeVM WorkshopWorkTimeVM)
        {
            var depart = _WorkshopWorkTimeServices.EditWorkshopWorkTime(WorkshopWorkTimeVM);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopWorkTime/GetAllWorkshopWorkTime
        [HttpGet]
        [Route("GetAllWorkshopWorkTime")]
        public IResponseDTO GetAllWorkshopWorkTime()
        {
            var depart = _WorkshopWorkTimeServices.GetAllWorkshopWorkTime();
            return depart;
        }
        #endregion

        #region Get: api/WorkshopWorkTime/GetWorkshopWorkTimeById
        [HttpGet]
        [Route("GetWorkshopWorkTimeById")]
        public IResponseDTO GetById(object id)
        {
            var depart = _WorkshopWorkTimeServices.GetByIDWorkshopWorkTime(id);
            return depart;
        }
        #endregion

        #region Delete: api/WorkshopWorkTime/RemoveWorkshopWorkTime
        [HttpDelete]
        [Route("RemoveWorkshopWorkTime")]
        public IResponseDTO RemoveWorkshopWorkTime(WorkshopWorkTimeVM WorkshopWorkTimeVM)
        {
            var depart = _WorkshopWorkTimeServices.DeleteWorkshopWorkTime(WorkshopWorkTimeVM);
            return depart;
        }
        #endregion
    }
}