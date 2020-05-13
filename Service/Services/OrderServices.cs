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
    public class OrderServices : IServicesOrder
    {
        #region PrivateField
        private readonly IGRepository<Order> _OrderRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public OrderServices(IGRepository<Order> Order,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _OrderRepositroy = Order;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteOrder(OrderVM model)
        public IResponseDTO DeleteOrder(OrderVM model)
        {
            try
            {

                var DbOrder = _mapper.Map<Order>(model);
                var entityEntry = _OrderRepositroy.Remove(DbOrder);


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
        #endregion

        #region EditOrder(OrderVM model)
        public IResponseDTO EditOrder(OrderVM model)
        {
            try
            {
                var DbOrder = _mapper.Map<Order>(model);
                var entityEntry = _OrderRepositroy.Update(DbOrder);


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
        #endregion

        #region GetAllOrder()
        public IResponseDTO GetAllOrder()
        {
            try
            {
                var Orders = _OrderRepositroy.GetAll();


                var OrdersList = _mapper.Map<List<OrderVM>>(Orders);
                _response.Data = OrdersList;
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
        #endregion

        #region GetByIDOrder(object id)
        public IResponseDTO GetByIDOrder(object id)
        {
            try
            {
                var Orders = _OrderRepositroy.Find(id);


                var OrdersList = _mapper.Map<OrderVM>(Orders);
                _response.Data = OrdersList;
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
        #endregion

        #region PostOrder(OrderVM model)
        public IResponseDTO PostOrder(OrderVM model)
        {

            try
            {
                var DbOrder = _mapper.Map<Order>(model);

                var Order = _mapper.Map<OrderVM>(_OrderRepositroy.Add(DbOrder));

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
        #endregion

        #region GetByCustomerId(Guid? id)
        public IResponseDTO GetByCustomerId(Guid? id)
        {
            try
            {
                var Orders = _OrderRepositroy.Get(x => x.CustomerId == id,includeProperties: "Workshop");


                var OrdersList = _mapper.Map<List<OrderVM>>(Orders);
                _response.Data = OrdersList;
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
        #endregion

        #region GetByWorkshopId(Guid? id)
        public IResponseDTO GetByWorkshopId(Guid? id)
        {
            try
            {
                var Orders = _OrderRepositroy.Get(x => x.WorkshopId == id,includeProperties: "Customer");


                var OrdersList = _mapper.Map<List<OrderVM>>(Orders);
                _response.Data = OrdersList;
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
        #endregion
    }
}
