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
    public class CustomerServices : IServicesCustomer
    {
        #region PrivateField
        private readonly IGRepository<Customer> _CustomerRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CustomerServices(IGRepository<Customer> Customer,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _CustomerRepositroy = Customer;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteCustomer(CustomerVM model)
        public IResponseDTO DeleteCustomer(CustomerVM model)
        {
            try
            {

                var DbCustomer = _mapper.Map<Customer>(model);
                var entityEntry = _CustomerRepositroy.Remove(DbCustomer);


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

        #region EditCustomer(CustomerVM model)
        public IResponseDTO EditCustomer(CustomerVM model)
        {
            try
            {
                var DbCustomer = _mapper.Map<Customer>(model);
                var entityEntry = _CustomerRepositroy.Update(DbCustomer);


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

        #region GetAllCustomer()
        public IResponseDTO GetAllCustomer()
        {
            try
            {
                var Customers = _CustomerRepositroy.GetAll();


                var CustomersList = _mapper.Map<List<CustomerVM>>(Customers);
                _response.Data = CustomersList;
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

        #region CustomerLogin(CustomerVM model)
        public IResponseDTO CustomerLogin(CustomerVM model)
        {
            try
            {
                var res = _CustomerRepositroy.GetFirst(X => X.Email == model.Email && X.Password == model.Password);
                if(res == null)
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }
                else
                {
                    //var DbCustomer = _mapper.Map<CustomerVM>(res);
                    //_response.Data = DbCustomer;
                    //_response.IsPassed = true;
                    //_response.Message = "Ok";
                    res.Token = model.Token;
                    return EditCustomer(_mapper.Map<CustomerVM>(res));
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

        #region GetByIDCustomer(object id)
        public IResponseDTO GetByIDCustomer(object id)
        {
            try
            {
                var Customers = _CustomerRepositroy.Find(id);


                var CustomersList = _mapper.Map<CustomerVM>(Customers);
                _response.Data = CustomersList;
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

        #region PostCustomer(CustomerVM model)
        public IResponseDTO PostCustomer(CustomerVM model)
        {

            try
            {
                var DbCustomer = _mapper.Map<Customer>(model);

                var Customer = _mapper.Map<CustomerVM>(_CustomerRepositroy.Add(DbCustomer));

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
        #region updateWorkshopToken(WorkshopVM model)
        public IResponseDTO UpdateCustomerToken(Guid CustomerId, string Token)
        {
            try
            {
                var res = _CustomerRepositroy.GetFirst(x => x.CustomerId == CustomerId);
                if (res == null)
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }
                else
                {

                    res.Token = Token;
                    return EditCustomer(_mapper.Map<CustomerVM>(res));
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
