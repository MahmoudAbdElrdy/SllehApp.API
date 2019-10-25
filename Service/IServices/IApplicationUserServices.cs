using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Service.IServices
{
   public interface IApplicationUserServices
    {
        Task<object> PostApplicationUserAsync(UserModel model);
          Task createRolesandUsers(string RoleName);
    }
}
