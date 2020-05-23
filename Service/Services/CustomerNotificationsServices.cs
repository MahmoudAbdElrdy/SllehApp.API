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
    public class CustomerNotificationsServices : IServicesCustomerNotifications
    {
        #region PrivateField
        private readonly IGRepository<CustomerNotifications> _CustomerNotificationsRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CustomerNotificationsServices(IGRepository<CustomerNotifications> CustomerNotifications,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _CustomerNotificationsRepositroy = CustomerNotifications;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteCustomerNotifications(CustomerNotificationsVM model)
        public IResponseDTO DeleteCustomerNotifications(CustomerNotificationsVM model)
        {
            try
            {

                var DbCustomerNotifications = _mapper.Map<CustomerNotifications>(model);
                var entityEntry = _CustomerNotificationsRepositroy.Remove(DbCustomerNotifications);


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

        #region EditCustomerNotifications(CustomerNotificationsVM model)
        public IResponseDTO EditCustomerNotifications(CustomerNotificationsVM model)
        {
            try
            {
                var DbCustomerNotifications = _mapper.Map<CustomerNotifications>(model);
                var entityEntry = _CustomerNotificationsRepositroy.Update(DbCustomerNotifications);


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

        #region UpdateCustomerNotificationsStatus(Guid CustomerNotificationId , bool Status)
        public IResponseDTO UpdateCustomerNotificationsStatus(Guid NotificationId , bool IsRead)
        {
            try
            {
                var DbCustomerNotifications = _CustomerNotificationsRepositroy.GetFirst(x => x.NotificationId == NotificationId);
                DbCustomerNotifications.IsRead = IsRead;
                var entityEntry = _CustomerNotificationsRepositroy.Update(DbCustomerNotifications);


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

        #region UpdateNotificationsStatus()
        public IResponseDTO UpdateNotificationsStatus(Guid? id)
        {
            try
            {
                var DbCustomerNotifications = _CustomerNotificationsRepositroy.GetAll(x=>x.CustomerId==id).ToList();
                foreach (var Notification in DbCustomerNotifications)
                {
                    Notification.IsRead = true;
                    _CustomerNotificationsRepositroy.Update(Notification);
                    _unitOfWork.Commit();
                }


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

        #region GetAllCustomerNotifications()
        public IResponseDTO GetAllCustomerNotifications()
        {
            try
            {
                var CustomerNotificationss = _CustomerNotificationsRepositroy.GetAll();


                var CustomerNotificationssList = _mapper.Map<List<CustomerNotificationsVM>>(CustomerNotificationss);
                var count = _CustomerNotificationsRepositroy.Get(x => x.IsRead == false).Count();
                _response.Data = new
                {
                    Notifications = CustomerNotificationssList,
                    countNew = count
                };
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

        #region GetByIDCustomerNotifications(object id)
        public IResponseDTO GetByIDCustomerNotifications(object id)
        {
            try
            {
                var CustomerNotificationss = _CustomerNotificationsRepositroy.Find(id);


                var CustomerNotificationssList = _mapper.Map<CustomerNotificationsVM>(CustomerNotificationss);
                _response.Data = CustomerNotificationssList;
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

        #region GetByCustomerId(Guid CustomerId)
        public IResponseDTO GetByCustomerId(Guid CustomerId)
        {
            try
            {
                var CustomerNotificationss = from enttity in _CustomerNotificationsRepositroy.Get(x => x.CustomerId == CustomerId)
                                             select new
                                             {
                                              enttity.Content,
                                             enttity.CreationDate,
                                             enttity.CustomerId,
                                             enttity.ImageUrl,
                                             enttity.IsRead,
                                             enttity.NotificationId,
                                             enttity.Title,
                                             };
                var CustomerNotificationssList = CustomerNotificationss.ToList();
                _response.Data = CustomerNotificationssList;
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

        #region PostCustomerNotifications(CustomerNotificationsVM model)
        public IResponseDTO PostCustomerNotifications(CustomerNotificationsVM model)
        {

            try
            {
                var DbCustomerNotifications = _mapper.Map<CustomerNotifications>(model);

                var CustomerNotifications = _mapper.Map<CustomerNotificationsVM>(_CustomerNotificationsRepositroy.Add(DbCustomerNotifications));

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
    }
}
