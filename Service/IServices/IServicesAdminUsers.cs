//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesAdminUsers
    {
        IResponseDTO PostAdminUsers(AdminUsersVM model);
        IResponseDTO GetAllAdminUsers();
        IResponseDTO EditAdminUsers(AdminUsersVM model);
        IResponseDTO DeleteAdminUsers(AdminUsersVM model);
        IResponseDTO GetByIDAdminUsers(object id);
        IResponseDTO AdminUsersLogin(AdminUsersVM model);
    }
}
