using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopNotificationsController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesWorkshopNotifications _WorkshopNotificationsServices;
        public WorkshopNotificationsController(IServicesWorkshopNotifications WorkshopNotificationsServices)
        {
            _WorkshopNotificationsServices = WorkshopNotificationsServices;
        }
        #endregion

        #region Post: api/WorkshopNotifications/SaveWorkshopNotifications
        [HttpPost]
        [Route("SaveWorkshopNotifications")]
        public IResponseDTO postWorkshopNotifications(WorkshopNotificationsVM WorkshopNotificationsVM)
        {
            var depart = _WorkshopNotificationsServices.PostWorkshopNotifications(WorkshopNotificationsVM);
            return depart;
        }
        #endregion

        #region Post: api/WorkshopNotifications/GetByWorkshopId
        [HttpGet]
        [Route("GetByWorkshopId")]
        public IResponseDTO GetByWorkshopId(Guid WorkshopId)
        {
            var depart = _WorkshopNotificationsServices.GetByWorkshopId(WorkshopId);
            return depart;
        }
        #endregion

        #region Put: api/WorkshopNotifications/UpdateWorkshopNotifications
        [HttpPut]
        [Route("UpdateWorkshopNotifications")]
        public IResponseDTO UpdateWorkshopNotifications(WorkshopNotificationsVM WorkshopNotificationsVM)
        {
            var depart = _WorkshopNotificationsServices.EditWorkshopNotifications(WorkshopNotificationsVM);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopNotifications/GetAllWorkshopNotifications
        [HttpGet]
        [Route("GetAllWorkshopNotifications")]
        public IResponseDTO GetAllWorkshopNotifications()
        {
            var depart = _WorkshopNotificationsServices.GetAllWorkshopNotifications();
            return depart;
        }
        #endregion

        #region Get: api/WorkshopNotifications/GetWorkshopNotificationsById
        [HttpGet]
        [Route("GetWorkshopNotificationsById")]
        public IResponseDTO GetById(object id)
        {
            var depart = _WorkshopNotificationsServices.GetByIDWorkshopNotifications(id);
            return depart;
        }
        #endregion

        #region Delete: api/WorkshopNotifications/RemoveWorkshopNotifications
        [HttpDelete]
        [Route("RemoveWorkshopNotifications")]
        public IResponseDTO RemoveWorkshopNotifications(WorkshopNotificationsVM WorkshopNotificationsVM)
        {
            var depart = _WorkshopNotificationsServices.DeleteWorkshopNotifications(WorkshopNotificationsVM);
            return depart;
        }
        #endregion
    }
}