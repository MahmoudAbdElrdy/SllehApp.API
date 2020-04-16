using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUsersController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesAdminUsers _AdminUsersServices;
        public AdminUsersController(IServicesAdminUsers AdminUsersServices)
        {
            _AdminUsersServices = AdminUsersServices;
        }
        #endregion

        #region Post: api/AdminUsers/SaveAdminUsers
        [HttpPost]
        [Route("SaveAdminUsers")]
        public IResponseDTO postAdminUsers(AdminUsersVM AdminUsersVM)
        {
            var depart = _AdminUsersServices.PostAdminUsers(AdminUsersVM);
            return depart;
        }
        #endregion

        //#region Post: api/Upload/UploadAdminUsersLog
        //[HttpPost]
        ////[Consumes("multipart/form-data")]
        //[Route("~/api/Upload/UploadAdminUsersLog")]
        //public IActionResult Upload()
        //{
        //    //var xx = UploadHelper.SaveFile(Request.Form.Files[0], "logo");
        //    ////string path = xx[0];
        //    //return Ok(xx);
        //    ResponseDTO res;
        //    try
        //    {
        //        var xx = UploadHelper.SaveFile(Request.Form.Files[0], "logo");
        //        //string path = xx[0];
        //        res = new ResponseDTO()
        //        {
        //            IsPassed = true,
        //            Message = "",
        //            Data = xx,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        res = new ResponseDTO()
        //        {
        //            IsPassed = false,
        //            Message = "Error " + ex.Message,
        //            Data = null,
        //        };
        //    }
        //    return Ok(res);
        //}
        //#endregion

        #region Post: api/AdminUsers/AdminUsersLogin
        [HttpPost]
        [Route("AdminUsersLogin")]
        public IResponseDTO AdminUsersLogin(Service.Models.AdminUsersVM AdminUsers)
        {
            var depart = _AdminUsersServices.AdminUsersLogin(AdminUsers);
            return depart;
        }
        #endregion

        #region Put: api/AdminUsers/UpdateAdminUsers
        [HttpPut]
        [Route("UpdateAdminUsers")]
        public IResponseDTO UpdateAdminUsers(AdminUsersVM AdminUsersVM)
        {
            var depart = _AdminUsersServices.EditAdminUsers(AdminUsersVM);
            return depart;
        }
        #endregion

        #region Get: api/AdminUsers/GetAllAdminUsers
        [HttpGet]
        [Route("GetAllAdminUsers")]
        public IResponseDTO GetAllAdminUsers()
        {
            var depart = _AdminUsersServices.GetAllAdminUsers();
            return depart;
        }
        #endregion

        #region Get: api/AdminUsers/GetAdminUsersById
        [HttpGet]
        [Route("GetAdminUsersById")]
        public IResponseDTO GetById(Guid ?id)
        {
            var depart = _AdminUsersServices.GetByIDAdminUsers(id);
            return depart;
        }
        #endregion

        #region Delete: api/AdminUsers/RemoveAdminUsers
        [HttpDelete]
        [Route("RemoveAdminUsers")]
        public IResponseDTO RemoveAdminUsers(AdminUsersVM AdminUsersVM)
        {
            var depart = _AdminUsersServices.DeleteAdminUsers(AdminUsersVM);
            return depart;
        }
        #endregion
    }
}