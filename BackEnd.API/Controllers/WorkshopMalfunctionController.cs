using System;
using System.Collections.Generic;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopMalfunctionController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesWorkshopMalfunction _WorkshopMalfunctionServices;
        public WorkshopMalfunctionController(IServicesWorkshopMalfunction WorkshopMalfunctionServices)
        {
            _WorkshopMalfunctionServices = WorkshopMalfunctionServices;
        }
        #endregion

        #region Post: api/WorkshopMalfunction/SaveWorkshopMalfunction
        [HttpPost]
        [Route("SaveWorkshopMalfunction")]
        public IResponseDTO postWorkshopMalfunction(WorkshopMalfunctionVM WorkshopMalfunctionVM)
        {
            var depart = _WorkshopMalfunctionServices.PostWorkshopMalfunction(WorkshopMalfunctionVM);
            return depart;
        }
        #endregion

        #region Put: api/WorkshopMalfunction/UpdateWorkshopMalfunction
        [HttpPut]
        [Route("UpdateWorkshopMalfunction")]
        public IResponseDTO UpdateWorkshopMalfunction(WorkshopMalfunctionVM WorkshopMalfunctionVM)
        {
            var depart = _WorkshopMalfunctionServices.EditWorkshopMalfunction(WorkshopMalfunctionVM);
            return depart;
        }
        [HttpPut]
        [Route("UpdateWorkshopMalfunctionList")]
        public IResponseDTO UpdateWorkshopMalfunctionList(List<WorkshopMalfunctionVM> WorkshopMalfunctionVM)
        {
            var depart = _WorkshopMalfunctionServices.EditWorkshopMalfunction(WorkshopMalfunctionVM);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopMalfunction/GetAllWorkshopMalfunction
        [HttpGet]
        [Route("GetAllWorkshopMalfunction")]
        public IResponseDTO GetAllWorkshopMalfunction()
        {
            var depart = _WorkshopMalfunctionServices.GetAllWorkshopMalfunction();
            return depart;
        }
        [HttpGet]
        [Route("GetAllByWorkshopId")]
        public IResponseDTO GetAllByWorkshopId(Guid id)
        {
            var depart = _WorkshopMalfunctionServices.GetAllWorkshopMalfunction(id);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopMalfunction/GetWorkshopMalfunctionById
        [HttpGet]
        [Route("GetWorkshopMalfunctionById")]
        public IResponseDTO GetById(object id)
        {
            var depart = _WorkshopMalfunctionServices.GetByIDWorkshopMalfunction(id);
            return depart;
        }
        #endregion

        #region Delete: api/WorkshopMalfunction/RemoveWorkshopMalfunction
        [HttpDelete]
        [Route("RemoveWorkshopMalfunction")]
        public IResponseDTO RemoveWorkshopMalfunction(WorkshopMalfunctionVM WorkshopMalfunctionVM)
        {
            var depart = _WorkshopMalfunctionServices.DeleteWorkshopMalfunction(WorkshopMalfunctionVM);
            return depart;
        }
        #endregion
    }
}