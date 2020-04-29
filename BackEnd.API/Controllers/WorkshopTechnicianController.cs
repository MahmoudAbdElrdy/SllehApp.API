using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopTechnicianController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesWorkshopTechnician _WorkshopTechnicianServices;
        public WorkshopTechnicianController(IServicesWorkshopTechnician WorkshopTechnicianServices)
        {
            _WorkshopTechnicianServices = WorkshopTechnicianServices;
        }
        #endregion

        #region Post: api/WorkshopTechnician/SaveWorkshopTechnician
        [HttpPost]
        [Route("SaveWorkshopTechnician")]
        public IResponseDTO postWorkshopTechnician(WorkshopTechnicianVM WorkshopTechnicianVM)
        {
            var depart = _WorkshopTechnicianServices.PostWorkshopTechnician(WorkshopTechnicianVM);
            return depart;
        }
        #endregion

        #region Put: api/WorkshopTechnician/UpdateWorkshopTechnician
        [HttpPut]
        [Route("UpdateWorkshopTechnician")]
        public IResponseDTO UpdateWorkshopTechnician(WorkshopTechnicianVM WorkshopTechnicianVM)
        {
            var depart = _WorkshopTechnicianServices.EditWorkshopTechnician(WorkshopTechnicianVM);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopTechnician/GetAllWorkshopTechnician
        [HttpGet]
        [Route("GetAllWorkshopTechnician")]
        public IResponseDTO GetAllWorkshopTechnician()
        {
            var depart = _WorkshopTechnicianServices.GetAllWorkshopTechnician();
            return depart;
        }
        #endregion

        #region Get: api/WorkshopTechnician/GetWorkshopTechnicianById
        [HttpGet]
        [Route("GetWorkshopTechnicianById")]
        public IResponseDTO GetById(object id)
        {
            var depart = _WorkshopTechnicianServices.GetByIDWorkshopTechnician(id);
            return depart;
        }
        #endregion

        #region Delete: api/WorkshopTechnician/RemoveWorkshopTechnician
        [HttpDelete]
        [Route("RemoveWorkshopTechnician")]
        public IResponseDTO RemoveWorkshopTechnician(WorkshopTechnicianVM WorkshopTechnicianVM)
        {
            var depart = _WorkshopTechnicianServices.DeleteWorkshopTechnician(WorkshopTechnicianVM);
            return depart;
        }
        #endregion
    }
}