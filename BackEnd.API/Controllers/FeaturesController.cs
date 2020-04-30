using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesFeatures _FeaturesServices;
        public FeaturesController(IServicesFeatures FeaturesServices)
        {
            _FeaturesServices = FeaturesServices;
        }
        #endregion

        #region Post: api/Features/SaveFeatures
        [HttpPost]
        [Route("SaveFeatures")]
        public IResponseDTO postFeatures(FeaturesVM FeaturesVM)
        {
            var depart = _FeaturesServices.PostFeatures(FeaturesVM);
            return depart;
        }
        #endregion

        #region Put: api/Features/UpdateFeatures
        [HttpPut]
        [Route("UpdateFeatures")]
        public IResponseDTO UpdateFeatures(FeaturesVM FeaturesVM)
        {
            var depart = _FeaturesServices.EditFeatures(FeaturesVM);
            return depart;
        }
        #endregion

        #region Get: api/Features/GetAllFeatures
        [HttpGet]
        [Route("GetAllFeatures")]
        public IResponseDTO GetAllFeatures()
        {
            var depart = _FeaturesServices.GetAllFeatures();
            return depart;
        }
        #endregion

        #region Get: api/Features/GetFeaturesById
        [HttpGet]
        [Route("GetFeaturesById")]
        public IResponseDTO GetById(object id)
        {
            var depart = _FeaturesServices.GetByIDFeatures(id);
            return depart;
        }
        #endregion

        #region Delete: api/Features/RemoveFeatures
        [HttpDelete]
        [Route("RemoveFeatures")]
        public IResponseDTO RemoveFeatures(FeaturesVM FeaturesVM)
        {
            var depart = _FeaturesServices.DeleteFeatures(FeaturesVM);
            return depart;
        }
        #endregion
    }
}