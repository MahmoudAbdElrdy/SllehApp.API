using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesCity _CityServices;
        public CityController(IServicesCity CityServices)
        {
            _CityServices = CityServices;
        }
        #endregion

        #region Post: api/City/SaveCity
        [HttpPost]
        [Route("SaveCity")]
        public IResponseDTO postCity(CityVM CityVM)
        {
            var depart = _CityServices.PostCity(CityVM);
            return depart;
        }
        #endregion

        #region Put: api/City/UpdateCity
        [HttpPut]
        [Route("UpdateCity")]
        public IResponseDTO UpdateCity(CityVM CityVM)
        {
            var depart = _CityServices.EditCity(CityVM);
            return depart;
        }
        #endregion

        #region Get: api/City/GetAllCity
        [HttpGet]
        [Route("GetAllCity")]
        public IResponseDTO GetAllCity()
        {
            var depart = _CityServices.GetAllCity();
            return depart;
        }
        #endregion
      
        #region Get: api/City/GetSaudiCity
        [HttpGet]
        [Route("GetSaudiCity")]
        public IResponseDTO GetSaudiCity()
        {
            var depart = _CityServices.GetSaudiCity();
            return depart;
        }
        #endregion

        #region Get: api/City/GetCityById
        [HttpGet]
        [Route("GetCityById")]
        public IResponseDTO GetById(Guid ?id)
        {
            var depart = _CityServices.GetByIDCity(id);
            return depart;
        }
        #endregion

        #region Delete: api/City/RemoveCity
        [HttpDelete]
        [Route("RemoveCity")]
        public IResponseDTO RemoveCity(CityVM CityVM)
        {
            var depart = _CityServices.DeleteCity(CityVM);
            return depart;
        }
        #endregion
    }
}