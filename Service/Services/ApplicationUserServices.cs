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
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace BackEnd.Service.Services
{
    public class ApplicationUserServices : IApplicationUserServices
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IPasswordHasher<ApplicationUser> _passwordHasher;
         private readonly ApplicationSettings _appSettings;
        private RoleManager<IdentityRole> _roleManager;
        //private IUnitOfWork<DatabaseContext> _unitOfWork;
        //private IGRepository<ApplicationUser> _user;
        private IResponseDTO _response;
        public ApplicationUserServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IPasswordHasher<ApplicationUser> passwordHash, RoleManager<IdentityRole> roleManager,IResponseDTO responseDTO, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHash;
             _appSettings = appSettings.Value;
            _roleManager = roleManager;
            _response = responseDTO;
            //_unitOfWork = unitOfWork;
            //_user = user;
        }
     
        public async Task<IResponseDTO> PostApplicationUserAsync(UserModel model)
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
                    _response.Data = applicationuser;
                    _response.IsPassed = true;
                    _response.Message = "OK";
                    return _response;
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        if (item.Code == "DuplicateUserName")
                        {
                            _response.Data = null;
                            _response.IsPassed = false;
                            _response.Message = "DuplicateUserName";
                            return _response;
                        }
                        if (item.Code == "InvalidUserName")
                        {
                            _response.Data = null;
                            _response.IsPassed = false;
                            _response.Message = "InvalidUserName";
                            return _response;
                        }
                    }
                    return (_response);
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
                        _response.Data = null;
                        _response.IsPassed = false;
                        _response.Message = "547";
                        return _response;

                    }
                    else
                        _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "6";
                    return _response;
                }
                return _response;

            }
        }
     
        public async Task<IResponseDTO> createRolesandUsers(string RoleName)
        {
            if(RoleName ==null)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "RoleName ISNULL";
                return _response;
            }
            bool x = await _roleManager.RoleExistsAsync(RoleName);
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = RoleName;
                await _roleManager.CreateAsync(role);
                _response.Data = role;
                _response.IsPassed = true;
                _response.Message = "OK";
                return _response;
            }
            _response.Data = null;
            _response.IsPassed = false;
            _response.Message = "RoleExists";
            return _response;

        }

        public async Task<IResponseDTO> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.LoginUserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.LoginPassword))
            {
                // Get Role assigned to the user 
                var UserRoles = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,UserRoles.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)),
                    SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                _response.IsPassed = true;
                _response.Message = "OK";
                _response.Data = token;
                return _response;
            }
            else
                _response.IsPassed = false;
            _response.Message = "Username or Password is incorrect";
            _response.Data = null;
            return _response;
        

        }
    }
}
