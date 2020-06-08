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
        #region PrivateField
        private readonly IGRepository<AdminUsers> _AdminUsersRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public AdminUsersServices(IGRepository<AdminUsers> AdminUsers,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _AdminUsersRepositroy = AdminUsers;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteAdminUsers(AdminUsersVM model)
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }
            return _response;
        }
        #endregion

        #region EditAdminUsers(AdminUsersVM model)
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }

            return _response;

        }
        #endregion

        #region GetAllAdminUsers()
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }
            return _response;
        }
        #endregion

        #region AdminUsersLogin(AdminUsersVM model)
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
                    var DbAdminUsers = _mapper.Map<AdminUsersVM>(res);
                    _response.Data = DbAdminUsers;
                    _response.IsPassed = true;
                    _response.Message = "Ok";
                }
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }
            return _response;
        }
        #endregion

        #region GetByIDAdminUsers(object id)
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }
            return _response;
        }
        #endregion

        #region PostAdminUsers(AdminUsersVM model)
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }


            return _response;

        }
        #endregion
    }
}
