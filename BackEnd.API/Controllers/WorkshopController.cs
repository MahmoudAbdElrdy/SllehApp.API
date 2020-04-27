using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesWorkshop _WorkshopServices;
        public WorkshopController(IServicesWorkshop WorkshopServices)
        {
            _WorkshopServices = WorkshopServices;
        }
        #endregion

        #region Post: api/Workshop/SaveWorkshop
        [HttpPost]
        [Route("SaveWorkshop")]
        public IResponseDTO postWorkshop(WorkshopVM WorkshopVM)
        {
            var depart = _WorkshopServices.PostWorkshop(WorkshopVM);
            return depart;
        }
        #endregion

        #region Post: api/Workshop/WorkshopLogin
        [HttpPost]
        [Route("WorkshopLogin")]
        public IResponseDTO WorkshopLogin(Service.Models.WorkshopVM Workshop)
        {
            var depart = _WorkshopServices.WorkshopLogin(Workshop);
            return depart;
        }
        #endregion

        #region Put: api/Workshop/UpdateWorkshop
        [HttpPut]
        [Route("UpdateWorkshop")]
        public IResponseDTO UpdateWorkshop(WorkshopVM WorkshopVM)
        {
            var depart = _WorkshopServices.EditWorkshop(WorkshopVM);
            return depart;
        }
        #endregion

        #region Get: api/Workshop/GetAllWorkshop
        [HttpGet]
        [Route("GetAllWorkshop")]
        public IResponseDTO GetAllWorkshop()
        {
            var depart = _WorkshopServices.GetAllWorkshop();
            return depart;
        }
        #endregion

        #region Get: api/Workshop/GetWorkshopById
        [HttpGet]
        [Route("GetWorkshopById")]
        public IResponseDTO GetById(Guid ?id)
        {
            var depart = _WorkshopServices.GetByIDWorkshop(id);
            return depart;
        }
        #endregion

        #region Delete: api/Workshop/RemoveWorkshop
        [HttpDelete]
        [Route("RemoveWorkshop")]
        public IResponseDTO RemoveWorkshop(WorkshopVM WorkshopVM)
        {
            var depart = _WorkshopServices.DeleteWorkshop(WorkshopVM);
            return depart;
        }
        #endregion
        #region Get: api/Workshop/GetAllWorkshop
        [HttpGet]
        [Route("GetAllNearestWorkShops")]
        public IResponseDTO GetAllNearestWorkShops(double MapLatitude, double MapLangitude, string Token)
        {
            var depart = _WorkshopServices.getNearestWorkShops(MapLatitude, MapLangitude, Token);
            return depart;
        }
        #endregion
    }
}