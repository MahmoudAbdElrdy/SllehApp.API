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
    private readonly    IApplicationUserServices _userServices;
        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public ApplicationUserController(IApplicationUserServices userServices, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userServices = userServices;
            _userManager = userManager;
            _roleManager = roleManager;
        }
       
        [HttpPost]
        //  [Authorize(Roles = "SuperAdmin")]
        [Route("Register")]
        //Post: /api/ApplicationUser/Register
        public async Task<IResponseDTO> PostApplicationUser(UserModel model)
        {
            return await _userServices.PostApplicationUserAsync(model);

        }

        [HttpPost]

        [Route("CreateRoles")]
        public async Task<IResponseDTO> CreateRoles(string RoleName)
        {

         return   await _userServices.createRolesandUsers(RoleName);
          
        }
    }
}