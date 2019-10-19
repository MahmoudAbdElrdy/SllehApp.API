using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        // private readonly ApplicationSettings _appSettings;
        private RoleManager<IdentityRole> _roleManager;
        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IPasswordHasher<ApplicationUser> passwordHash/*, IOptions<ApplicationSettings> appSettings*/, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            passwordHasher = passwordHash;
            //  _appSettings = appSettings.Value;
            _roleManager = roleManager;
        }
      //  #region Insert Method
      //  [HttpPost]
      ////  [Authorize(Roles = "SuperAdmin")]
      //  [Route("Register")]
      //  //Post: /api/ApplicationUser/Register
      //  public async Task<object> PostApplicationUser(UserModel model)
      //  {
      //      var applicationuser = new ApplicationUser()
      //      {
      //          UserName = model.UserName,
      //          Email = model.Email,
      //          FullName = model.FullName,
      //          Creationdate = DateTime.Now
      //      };

      //      try
      //      {
      //          var result = await _userManager.CreateAsync(applicationuser, model.Password);

      //          if (result.Succeeded)
      //          {
      //              await _userManager.AddToRoleAsync(applicationuser, model.Role);
      //              return Ok(result);
      //          }
      //          else
      //          {
      //              foreach (var item in result.Errors)
      //              {
      //                  if (item.Code == "DuplicateUserName")
      //                  {
      //                      return Ok(2);
      //                  }
      //                  if (item.Code == "InvalidUserName")
      //                  {
      //                      return Ok(1);
      //                  }
      //              }
      //              return Ok(result);
      //          }

      //      }
      //      catch (DbUpdateException ex)
      //      {

      //          var sqlException = ex.GetBaseException() as SqlException;

      //          if (sqlException != null)
      //          {
      //              var number = sqlException.Number;

      //              if (number == 547)
      //              {
      //                  return Ok(5);

      //              }
      //              else
      //                  return Ok(6);
      //          }
      //          return Ok(6);

      //      }
      //  }

    }
}