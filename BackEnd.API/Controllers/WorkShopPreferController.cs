using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShopPreferController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesWorkShopPrefer _WorkShopPreferServices;
        public WorkShopPreferController(IServicesWorkShopPrefer WorkShopPreferServices)
        {
            _WorkShopPreferServices = WorkShopPreferServices;
        }
        #endregion

        #region Post: api/WorkShopPrefer/SaveWorkShopPrefer
        [HttpPost]
        [Route("SaveWorkShopPrefer")]
        public IResponseDTO postWorkShopPrefer(WorkShopPreferVM WorkShopPreferVM)
        {
            var depart = _WorkShopPreferServices.PostWorkShopPrefer(WorkShopPreferVM);
            return depart;
        }
        #endregion

        #region Put: api/WorkShopPrefer/UpdateWorkShopPrefer
        [HttpPut]
        [Route("UpdateWorkShopPrefer")]
        public IResponseDTO UpdateWorkShopPrefer(WorkShopPreferVM WorkShopPreferVM)
        {
            var depart = _WorkShopPreferServices.EditWorkShopPrefer(WorkShopPreferVM);
            return depart;
        }
        #endregion

        #region Get: api/WorkShopPrefer/GetAllWorkShopPrefer
        [HttpGet]
        [Route("GetAllWorkShopPrefer")]
        public IResponseDTO GetAllWorkShopPrefer()
        {
            var depart = _WorkShopPreferServices.GetAllWorkShopPrefer();
            return depart;
        }
        [HttpGet]
        [Route("GetAllWorkShopPreferAdmin")]
        public IResponseDTO GetAllWorkShopPreferAdmin()
        {
            var depart = _WorkShopPreferServices.GetAllWorkShopPreferAdmin();
            return depart;
        }
        #endregion

        #region Get: api/WorkShopPrefer/GetWorkShopPreferById
        [HttpGet]
        [Route("GetWorkShopPreferById")]
        public IResponseDTO GetById(Guid ?id)
        {
            var depart = _WorkShopPreferServices.GetByIDWorkShopPrefer(id);
            return depart;
        }
        #endregion

        #region Get: api/WorkShopPrefer/GetByCustomerId
        [HttpGet]
        [Route("GetByCustomerId")]
        public IResponseDTO GetByCustomerId(Guid? id)
        {
            var depart = _WorkShopPreferServices.GetByCustomerId(id);
            return depart;
        }
        #endregion

        #region Get: api/WorkShopPrefer/GetByWorkshopId
        [HttpGet]
        [Route("GetByWorkshopId")]
        public IResponseDTO GetByWorkshopId(Guid? id)
        {
            var depart = _WorkShopPreferServices.GetByWorkshopId(id);
            return depart;
        }
        #endregion

        #region Get: api/WorkShopPrefer/GetRunningByWorkshopId
        [HttpGet]
        [Route("GetRunningByWorkshopId")]
        public IResponseDTO GetRunningByWorkshopId(Guid? id)
        {
            var depart = _WorkShopPreferServices.GetRunningByWorkshopId(id);
            return depart;
        }
        #endregion

        #region Delete: api/WorkShopPrefer/RemoveWorkShopPrefer
        [HttpDelete]
        [Route("RemoveWorkShopPrefer")]
        public IResponseDTO RemoveWorkShopPrefer(WorkShopPreferVM WorkShopPreferVM)
        {
            var depart = _WorkShopPreferServices.DeleteWorkShopPrefer(WorkShopPreferVM);
            return depart;
        }
        #endregion
    }
}