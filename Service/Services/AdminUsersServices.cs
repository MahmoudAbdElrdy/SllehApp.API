using AutoMapper;
//using BackEnd.DAL.Entities;
using BackEnd.DAL.Models;
using BackEnd.Repositories.Generics;
using BackEnd.Repositories.UOW;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
//using DAL;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Service.Services
{
    public class AdminUsersServices : IServicesAdminUsers
    {
        private readonly IGRepository<AdminUsers> _AdminUsersRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        public AdminUsersServices(IGRepository<AdminUsers> AdminUsers,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _AdminUsersRepositroy = AdminUsers;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        public IResponseDTO DeleteAdminUsers(AdminUsersVM model)
        {
            try
            {

                var DbAdminUsers = _mapper.Map<AdminUsers>(model);
                var entityEntry = _AdminUsersRepositroy.Remove(DbAdminUsers);


                int save = _unitOfWork.Commit();

                if (save == 200)
                {
                    _response.Data = null;
                    _response.IsPassed = true;
                    _response.Message = "Ok";
                }
                else
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }
            return _response;
        }
        public IResponseDTO EditAdminUsers(AdminUsersVM model)
        {
            try
            {
                var DbAdminUsers = _mapper.Map<AdminUsers>(model);
                var entityEntry = _AdminUsersRepositroy.Update(DbAdminUsers);


                int save = _unitOfWork.Commit();

                if (save == 200)
                {
                    _response.Data = model;
                    _response.IsPassed = true;
                    _response.Message = "Ok";
                }
                else
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }

            return _response;

        }
        public IResponseDTO GetAllAdminUsers()
        {
            try
            {
                var AdminUserss = _AdminUsersRepositroy.GetAll();


                var AdminUserssList = _mapper.Map<List<AdminUsersVM>>(AdminUserss);
                _response.Data = AdminUserssList;
                _response.IsPassed = true;
                _response.Message = "Done";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }
            return _response;
        }
        public IResponseDTO AdminUsersLogin(AdminUsersVM model)
        {
            try
            {
                var res = _AdminUsersRepositroy.GetFirst(X => X.UserName == model.UserName && X.Password == model.Password);
                if(res == null)
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }
                else
                {
                    var DbAdminUsers = _mapper.Map<AdminUsersVM>(model);
                    _response.Data = DbAdminUsers;
                    _response.IsPassed = true;
                    _response.Message = "Ok";
                }
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }
            return _response;
        }
        public IResponseDTO GetByIDAdminUsers(object id)
        {
            try
            {
                var AdminUserss = _AdminUsersRepositroy.Find(id);


                var AdminUserssList = _mapper.Map<AdminUsersVM>(AdminUserss);
                _response.Data = AdminUserssList;
                _response.IsPassed = true;
                _response.Message = "Done";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }
            return _response;
        }
        public IResponseDTO PostAdminUsers(AdminUsersVM model)
        {

            try
            {
                var DbAdminUsers = _mapper.Map<AdminUsers>(model);

                var AdminUsers = _mapper.Map<AdminUsersVM>(_AdminUsersRepositroy.Add(DbAdminUsers));

                int save = _unitOfWork.Commit();

                if (save == 200)
                {
                    _response.Data = model;
                    _response.IsPassed = true;
                    _response.Message = "Ok";
                }
                else
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }

            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }


            return _response;

        }
    }
}
