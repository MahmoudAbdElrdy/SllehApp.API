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
        private readonly IGRepository<Workshop> _WorkshopRepositroy;
        private readonly IGRepository<CustomerNotifications> _CustomerNotificationsRepositroy;
        private readonly IGRepository<WorkshopNotifications> _WorkshopNotificationsRepositroy;
        private readonly IGRepository<Customer> _CustomerRepositroy;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public OrderServices(IGRepository<Order> Order, IGRepository<Customer> customer, IGRepository<Workshop> Workshop,
            IGRepository<CustomerNotifications> CustomerNotifications, IGRepository<WorkshopNotifications> WorkshopNotifications,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _OrderRepositroy = Order;
            _unitOfWork = unitOfWork;
            _CustomerRepositroy = customer;
            _WorkshopRepositroy = Workshop;
            _CustomerNotificationsRepositroy = CustomerNotifications;
            _WorkshopNotificationsRepositroy = WorkshopNotifications;
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }
            return _response;
        }
        #endregion

        #region EditOrder(OrderVM model)
        public IResponseDTO EditOrder(OrderVM model)
        {
            try
            {
                int OldStuts = (int)_OrderRepositroy.GetFirst(x => x.OrderId == model.OrderId).Status;
                var DbOrder = _mapper.Map<Order>(model);
                var entityEntry = _OrderRepositroy.Update(DbOrder);
                if (OldStuts != model.Status) 
                {
                    bool _notification = SendNotification(model);
                }
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

        #region SendNotification(OrderVM model)
        public bool SendNotification(OrderVM model)
        {
            try
            {

                var customer = _CustomerRepositroy.GetFirst(x => x.CustomerId == model.CustomerId);
                var workshop = _WorkshopRepositroy.GetFirst(x => x.WorkshopId == model.WorkshopId);
                string _title = "", _message = "", _token = "",_status = "";
                Dictionary<string, object> AdditionalData = new Dictionary<string, object>()
                {
                    { "IsOrder" , true},
                    { "CustomerId" , model.CustomerId},
                    { "WorkshopId" , model.WorkshopId},
                    { "OrderId" , model.OrderId},
                };
                if (model.IsCustomer == true)
                {
                    _title = customer.Name;
                    if(model.Status == 1)
                    {
                        _status = "بدأ طلبيه جديد";
                    }
                    else if (model.Status == 2)
                    {
                        _status = "استلام السيارة وفحصها والقبول التصليحات";
                    }
                    else if (model.Status == 3)
                    {
                        _status = "بإلغاء الطلبيه";
                    }
                    _message = $"لقد قام العميل {customer.Name} بـ{_status}";
                    _token = workshop.Token;
                    _WorkshopNotificationsRepositroy.Add(_mapper.Map<WorkshopNotifications>(new WorkshopNotificationsVM()
                    {
                        WorkshopId = model.WorkshopId,
                        Content = _message,
                        Title = _title,
                    }));
                }
                else
                {
                    _title = workshop.Name;
                    if (model.Status == 1)
                    {
                        _status = "بدأ طلبيه جديد";
                    }
                    else if (model.Status == 2)
                    {
                        _status = "اكمال الاصلاحات المطلوبة وانهاء الطلبيه";
                    }
                    else if (model.Status == 3)
                    {
                        _status = "بإلغاء الطلبيه";
                    }
                    _message = $"لقد قامت ورشة {workshop.Name} بـ{_status}";
                    _token = workshop.Token;
                    _CustomerNotificationsRepositroy.Add(_mapper.Map<CustomerNotifications>(new CustomerNotificationsVM()
                    {
                        CustomerId = model.CustomerId,
                        Content = _message,
                        Title = _title,
                    }));
                }
                Helper.NotificationHelper.PushNotificationByFirebase(_message, _title, new List<string>() { _token }, AdditionalData);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return false;
            }
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }
            return _response;
        }
        #endregion

        #region GetRunningByWorkshopId(Guid? id)
        public IResponseDTO GetRunningByWorkshopId(Guid? id)
        {
            try
            {
                var Orders = _OrderRepositroy.Get(x => x.WorkshopId == id && x.Status == 1, includeProperties: "Customer");


                var OrdersList = _mapper.Map<List<OrderVM>>(Orders);
                _response.Data = OrdersList;
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
    }
}
