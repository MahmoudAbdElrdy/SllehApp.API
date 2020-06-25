using System;
using System.Collections.Generic;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopFeaturesController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesWorkshopFeatures _WorkshopFeaturesServices;
        public WorkshopFeaturesController(IServicesWorkshopFeatures WorkshopFeaturesServices)
        {
            _WorkshopFeaturesServices = WorkshopFeaturesServices;
        }
        #endregion

        #region Post: api/WorkshopFeatures/SaveWorkshopFeatures
        [HttpPost]
        [Route("SaveWorkshopFeatures")]
        public IResponseDTO postWorkshopFeatures(WorkshopFeaturesVM WorkshopFeaturesVM)
        {
            var depart = _WorkshopFeaturesServices.PostWorkshopFeatures(WorkshopFeaturesVM);
            return depart;
        }
        #endregion

        #region Put: api/WorkshopFeatures/UpdateWorkshopFeatures
        [HttpPut]
        [Route("UpdateWorkshopFeaturesList")]
        public IResponseDTO UpdateWorkshopFeaturesList(List<WorkshopFeaturesVM> WorkshopFeaturesVM)
        {
            var depart = _WorkshopFeaturesServices.EditWorkshopFeatures(WorkshopFeaturesVM);
            return depart;
        }
        [HttpPut]
        [Route("UpdateWorkshopFeatures")]
        public IResponseDTO UpdateWorkshopFeatures(WorkshopFeaturesVM WorkshopFeaturesVM)
        {
            var depart = _WorkshopFeaturesServices.EditWorkshopFeatures(WorkshopFeaturesVM);
            return depart;
        }
        #endregion

        #region Get: api/WorkshopFeatures/GetAllWorkshopFeatures
        [HttpGet]
        [Route("GetAllWorkshopFeatures")]
        public IResponseDTO GetAllWorkshopFeatures()
        {
            var depart = _WorkshopFeaturesServices.GetAllWorkshopFeatures();
            return depart;
        }
        [HttpGet]
        [Route("GetAllByWorkShopId")]
        public IResponseDTO GetAllByWorkShopId(Guid? guid)
        {
            if (guid == null)
            {
                var depart = _WorkshopFeaturesServices.GetAllWorkshopFeature();
                return depart;
            }
            else
            {
                var depart = _WorkshopFeaturesServices.GetAllWorkshopFeatures((Guid)guid);
                return depart;

            }
          
        }
        #endregion

        #region Get: api/WorkshopFeatures/GetWorkshopFeaturesById
        [HttpGet]
        [Route("GetWorkshopFeaturesById")]
        public IResponseDTO GetById(object id)
        {
            var depart = _WorkshopFeaturesServices.GetByIDWorkshopFeatures(id);
            return depart;
        }
        #endregion

        #region Delete: api/WorkshopFeatures/RemoveWorkshopFeatures
        [HttpDelete]
        [Route("RemoveWorkshopFeatures")]
        public IResponseDTO RemoveWorkshopFeatures(WorkshopFeaturesVM WorkshopFeaturesVM)
        {
            var depart = _WorkshopFeaturesServices.DeleteWorkshopFeatures(WorkshopFeaturesVM);
            return depart;
        }
        #endregion
    }
}