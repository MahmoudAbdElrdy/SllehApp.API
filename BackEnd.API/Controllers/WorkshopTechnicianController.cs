using System;
using System.Collections.Generic;
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

        #region Post: api/WorkshopTechnician/NewSaveWorkshopTechnician
        [HttpPost]
        [Route("NewSaveWorkshopTechnician")]
        public IResponseDTO NewSaveWorkshopTechnician([FromForm]WorkshopTechnicianVM WorkshopTechnicianVM)
        {
            ResponseDTO res;
            try
            {
                if (WorkshopTechnicianVM.DataFile != null)
                {
                    var logoUrl = BackEnd.API.Hlper.UploadHelper.SaveFile(WorkshopTechnicianVM.DataFile, "File");
                    WorkshopTechnicianVM.ImageUrl = logoUrl;
                }
                return _WorkshopTechnicianServices.PostWorkshopTechnician(WorkshopTechnicianVM);
            }
            catch (Exception ex)
            {
                res = new ResponseDTO()
                {
                    IsPassed = false,
                    Message = "Error in Upload File " + ex.Message,
                    Data = null,
                };
            }
            return res;
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

        #region Post: api/WorkshopTechnician/SaveListOfTechnician
        [HttpPost]
        [Route("SaveListOfTechnician")]
        public IResponseDTO SaveListOfTechnician(System.Collections.Generic.List<WorkshopTechnicianVM> WorkshopTechnicianVM)
        {
            var depart = _WorkshopTechnicianServices.PostWorkshopTechnician(WorkshopTechnicianVM);
            return depart;
        }
        #endregion

        #region Post: api/WorkshopTechnician/NewSaveListOfTechnician
        [HttpPost]
        [Route("NewSaveListOfTechnician")]
        public IResponseDTO NewSaveListOfTechnician([FromForm]System.Collections.Generic.List<WorkshopTechnicianVM> WorkshopTechnicianVM)
        {
            ResponseDTO res;
            try
            {
                foreach (var t in WorkshopTechnicianVM)
                {
                    if (t.DataFile != null)
                    {
                        var logoUrl = BackEnd.API.Hlper.UploadHelper.SaveFile(t.DataFile, "File");
                        t.ImageUrl = logoUrl;
                    }
                }
                var depart = _WorkshopTechnicianServices.PostWorkshopTechnician(WorkshopTechnicianVM);
                return depart;
            }
            catch (Exception ex)
            {
                res = new ResponseDTO()
                {
                    IsPassed = false,
                    Message = "Error in Upload File " + ex.Message,
                    Data = null,
                };
            }
            return res;
        }
        #endregion

        #region Put: api/WorkshopTechnician/UpdateWorkshopTechnician
        [HttpPut]
        [Route("UpdateWorkshopTechnicianList")]
        public IResponseDTO UpdateWorkshopTechnicianList(List<WorkshopTechnicianVM> WorkshopTechnicianVM)
        {
            var depart = _WorkshopTechnicianServices.EditWorkshopTechnician(WorkshopTechnicianVM);
            return depart;
        }
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
        [HttpGet]
        [Route("GetAllByWorkshopId")]
        public IResponseDTO GetAllByWorkshopId(Guid id)
        {
            var depart = _WorkshopTechnicianServices.GetAllWorkshopTechnician(id);
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