using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MalfunctionController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesMalfunction _MalfunctionServices;
        public MalfunctionController(IServicesMalfunction MalfunctionServices)
        {
            _MalfunctionServices = MalfunctionServices;
        }
        #endregion

        #region Post: api/Malfunction/SaveMalfunction
        [HttpPost]
        [Route("SaveMalfunction")]
        public IResponseDTO postMalfunction(MalfunctionVM MalfunctionVM)
        {
            var depart = _MalfunctionServices.PostMalfunction(MalfunctionVM);
            return depart;
        }
        #endregion

        #region Put: api/Malfunction/UpdateMalfunction
        [HttpPut]
        [Route("UpdateMalfunction")]
        public IResponseDTO UpdateMalfunction(MalfunctionVM MalfunctionVM)
        {
            var depart = _MalfunctionServices.EditMalfunction(MalfunctionVM);
            return depart;
        }
        #endregion

        #region Get: api/Malfunction/GetAllMalfunction
        [HttpGet]
        [Route("GetAllMalfunction")]
        public IResponseDTO GetAllMalfunction()
        {
            var depart = _MalfunctionServices.GetAllMalfunction();
            return depart;
        }
        #endregion

        #region Get: api/Malfunction/GetMalfunctionById
        [HttpGet]
        [Route("GetMalfunctionById")]
        public IResponseDTO GetById(object id)
        {
            var depart = _MalfunctionServices.GetByIDMalfunction(id);
            return depart;
        }
        #endregion

        #region Delete: api/Malfunction/RemoveMalfunction
        [HttpDelete]
        [Route("RemoveMalfunction")]
        public IResponseDTO RemoveMalfunction(MalfunctionVM MalfunctionVM)
        {
            var depart = _MalfunctionServices.DeleteMalfunction(MalfunctionVM);
            return depart;
        }
        #endregion
    }
}