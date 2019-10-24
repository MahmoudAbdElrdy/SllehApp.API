using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Repositories.Generics;
using BackEnd.Repositories.UOW;
using DAL;

namespace BackEnd.Service.Services
{
    public class ApplicationUserServices : IApplicationUserServices
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        // private readonly ApplicationSettings _appSettings;
        private RoleManager<IdentityRole> _roleManager;
        //private IUnitOfWork<DatabaseContext> _unitOfWork;
        //private IGRepository<ApplicationUser> _user;

        public ApplicationUserServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IPasswordHasher<ApplicationUser> passwordHash/*, IGRepository<ApplicationUser> user, IUnitOfWork<DatabaseContext> unitOfWork,, IOptions<ApplicationSettings> appSettings*/, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            passwordHasher = passwordHash;
            //  _appSettings = appSettings.Value;
            _roleManager = roleManager;
            //_unitOfWork = unitOfWork;
            //_user = user;
        }
     
        public async Task<object> PostApplicationUserAsync(UserModel model)
        {
            var applicationuser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                Creationdate = DateTime.Now
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationuser, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationuser, model.Role);
                    return result;
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        if (item.Code == "DuplicateUserName")
                        {
                            return 2;
                        }
                        if (item.Code == "InvalidUserName")
                        {
                            return (1);
                        }
                    }
                    return (result);
                }

            }
            catch (DbUpdateException ex)
            {

                var sqlException = ex.GetBaseException() as SqlException;

                if (sqlException != null)
                {
                    var number = sqlException.Number;

                    if (number == 547)
                    {
                        return (5);

                    }
                    else
                        return (6);
                }
                return (6);

            }
        }
    }
}
