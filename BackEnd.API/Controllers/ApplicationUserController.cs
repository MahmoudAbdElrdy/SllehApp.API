using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
    private readonly    IApplicationUserServices userServices;
        public ApplicationUserController(IApplicationUserServices _userServices)
        {
            userServices = _userServices;
        }
       
        [HttpPost]
        //  [Authorize(Roles = "SuperAdmin")]
        [Route("Register")]
        //Post: /api/ApplicationUser/Register
        public async Task<object> PostApplicationUser(UserModel model)
        {
            return userServices.PostApplicationUserAsync(model);

        }

    }
}