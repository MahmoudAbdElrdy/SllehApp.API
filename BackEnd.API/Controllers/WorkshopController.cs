﻿using System;
using System.Collections.Generic;
using BackEnd.API.Hlper;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using BackEnd.Service.Services;
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

        #region Post: api/Upload/UploadWorkshop
        [HttpPost]
        //[Consumes("multipart/form-data")]
        [Route("~/api/Upload/UploadWorkshop")]
        public IActionResult Upload()
        {
            //var xx = UploadHelper.SaveFile(Request.Form.Files[0], "File");
            ////string path = xx[0];
            //return Ok(xx);
            ResponseDTO res;
            try
            {
                var xx = UploadHelper.SaveFile(Request.Form.Files[0], "Workshop");
                //string path = xx[0];
                res = new ResponseDTO()
                {
                    IsPassed = true,
                    Message = "",
                    Data = xx,
                };
            }
            catch (Exception ex)
            {
                res = new ResponseDTO()
                {
                    IsPassed = false,
                    Message = "Error " + ex.Message,
                    Data = null,
                };
            }
            return Ok(res);
        }
        #endregion

        #region Post: api/Workshop/NewSignup
        [HttpPost]
        [Route("NewSignup")]
        public IResponseDTO NewSignup([FromForm]WorkshopSVM Workshop)
        {
            ResponseDTO res;
            try
            {
                if (Workshop.ShopFile != null)
                {
                    var logoUrl = BackEnd.API.Hlper.UploadHelper.SaveFile(Workshop.ShopFile, "File");
                    Workshop.ImageUrl = logoUrl;
                    Workshop.ShopFile = null;
                }
                if (Workshop.OwnerFile != null)
                {
                    var logoUrl = BackEnd.API.Hlper.UploadHelper.SaveFile(Workshop.OwnerFile, "File");
                    Workshop.OwnerImage = logoUrl;
                    Workshop.OwnerFile = null;
                }
                return _WorkshopServices.Signup(Workshop);
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

        #region Post: api/Workshop/Signup
        [HttpPost]
        [Route("Signup")]
        public IResponseDTO Signup(WorkshopSVM Workshop)
        {
            var depart = _WorkshopServices.Signup(Workshop);
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

        #region Post: api/Workshop/NewUpdateWorkshop
        [HttpPost]
        [Route("NewUpdateWorkshop")]
        public IResponseDTO NewUpdateWorkshop([FromForm]WorkshopVM Workshop)
        {
            ResponseDTO res;
            try
            {
                if (Workshop.ShopFile != null)
                {
                    var logoUrl = BackEnd.API.Hlper.UploadHelper.SaveFile(Workshop.ShopFile, "File");
                    Workshop.ImageUrl = logoUrl;
                    Workshop.ShopFile = null;
                }
                if (Workshop.OwnerFile != null)
                {
                    var logoUrl = BackEnd.API.Hlper.UploadHelper.SaveFile(Workshop.OwnerFile, "File");
                    Workshop.OwnerImage = logoUrl;
                    Workshop.OwnerFile = null;
                }
                return _WorkshopServices.EditWorkshop(Workshop);
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

        #region Put: api/Workshop/UpdateWorkshop
        [HttpPut]
        [Route("UpdateWorkshop")]
        public IResponseDTO UpdateWorkshop(WorkshopVM WorkshopVM)
        {
            var depart = _WorkshopServices.EditWorkshop(WorkshopVM);
            return depart;
        }
        #endregion
        
        #region Put: api/Workshop/UpdateAllWorkshop
        [HttpPut]
        [Route("UpdateAllWorkshop")]
        public IResponseDTO UpdateAllWorkshop(WorkshopSVM WorkshopVM)
        {
            var depart = _WorkshopServices.UpdateWorkshop(WorkshopVM);
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

        #region Get: api/Workshop/GetAllWorkshopCity
        [HttpGet]
        [Route("GetAllWorkshopCity")]
        public IResponseDTO GetAllWorkshopCity()
        {
            var depart = _WorkshopServices.GetAllWorkshopCity();
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

        #region Get: api/Workshop/UpdateStatus
        [HttpGet]
        [Route("UpdateStatus")]
        public IResponseDTO UpdateStatus(Guid WorkshopId)
        {
            var depart = _WorkshopServices.UpdateStatus(WorkshopId);
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

        #region Get: api/Workshop/GetAllNearestWorkShops
        [HttpGet]
        [Route("GetAllNearestWorkShops")]
        public IResponseDTO GetAllNearestWorkShops(double MapLatitude, double MapLangitude, string Token)
        {
            var depart = _WorkshopServices.getNearestWorkShops(MapLatitude, MapLangitude, Token);
            return depart;
        }
        #endregion

        #region Get: api/Workshop/GetAllWorkshop
        [HttpGet]
        [Route("GetAllWorkshopDeatalis")]
        public IResponseDTO GetAllWorkshopDeatalis(Guid id)
        {
            var depart = _WorkshopServices.GetAllWorkshopDeatalis(id);
            return depart;
        }
        #endregion

        #region Post: api/Workshop/Search
        [HttpPost]
        [Route("Search")]
        public IResponseDTO Search(Data data)
        {
           

               var depart = _WorkshopServices.SearchWorkShop(data);
            return depart;
        }
        #endregion

        #region Get: api/Workshop/UpdateWorkshopToken
        [HttpGet]
        [Route("UpdateWorkshopToken")]
        public IResponseDTO UpdateWorkshopToken(Guid id,string Token)
        {
            var depart = _WorkshopServices.UpdateWorkshopToken(id,Token);
            return depart;
        }
        #endregion
    }
}