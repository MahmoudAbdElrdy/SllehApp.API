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
    public class WorkshopNotificationsServices : IServicesWorkshopNotifications
    {
        #region PrivateField
        private readonly IGRepository<WorkshopNotifications> _WorkshopNotificationsRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkshopNotificationsServices(IGRepository<WorkshopNotifications> WorkshopNotifications,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _WorkshopNotificationsRepositroy = WorkshopNotifications;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteWorkshopNotifications(WorkshopNotificationsVM model)
        public IResponseDTO DeleteWorkshopNotifications(WorkshopNotificationsVM model)
        {
            try
            {

                var DbWorkshopNotifications = _mapper.Map<WorkshopNotifications>(model);
                var entityEntry = _WorkshopNotificationsRepositroy.Remove(DbWorkshopNotifications);


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

        #region EditWorkshopNotifications(WorkshopNotificationsVM model)
        public IResponseDTO EditWorkshopNotifications(WorkshopNotificationsVM model)
        {
            try
            {
                var DbWorkshopNotifications = _mapper.Map<WorkshopNotifications>(model);
                var entityEntry = _WorkshopNotificationsRepositroy.Update(DbWorkshopNotifications);


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

        #region UpdateWorkshopNotificationsStatus(Guid WorkshopNotificationId , bool Status)
        public IResponseDTO UpdateWorkshopNotificationsStatus(Guid NotificationId, bool IsRead)
        {
            try
            {
                var DbWorkshopNotifications = _WorkshopNotificationsRepositroy.GetFirst(x => x.NotificationId == NotificationId);
                DbWorkshopNotifications.IsRead = IsRead;
                var entityEntry = _WorkshopNotificationsRepositroy.Update(DbWorkshopNotifications);


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
        public IResponseDTO UpdateNotificationsStatus()
        {
            try
            {
                var DbWorkshopNotifications = _WorkshopNotificationsRepositroy.GetAll().ToList();
                foreach (var Notification in DbWorkshopNotifications)
                {
                    Notification.IsRead = true;
                    _WorkshopNotificationsRepositroy.Update(Notification);
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

        #region GetAllWorkshopNotifications()
        public IResponseDTO GetAllWorkshopNotifications()
        {
            try
            {
                var WorkshopNotificationss = _WorkshopNotificationsRepositroy.GetAll();


                var WorkshopNotificationssList = _mapper.Map<List<WorkshopNotificationsVM>>(WorkshopNotificationss);
                var count = _WorkshopNotificationsRepositroy.Get(x => x.IsRead == false).Count();
                _response.Data = new
                {
                    Notifications = WorkshopNotificationssList,
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

        #region GetByIDWorkshopNotifications(object id)
        public IResponseDTO GetByIDWorkshopNotifications(object id)
        {
            try
            {
                var WorkshopNotificationss = _WorkshopNotificationsRepositroy.Find(id);


                var WorkshopNotificationssList = _mapper.Map<WorkshopNotificationsVM>(WorkshopNotificationss);
                _response.Data = WorkshopNotificationssList;
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

        #region GetByWorkshopId(Guid WorkshopId)
        public IResponseDTO GetByWorkshopId(Guid WorkshopId)
        {
            try
            {
                var WorkshopNotificationss = _WorkshopNotificationsRepositroy.Get(x => x.WorkshopId == WorkshopId);


                var WorkshopNotificationssList = _mapper.Map<WorkshopNotificationsVM>(WorkshopNotificationss);
                _response.Data = WorkshopNotificationssList;
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

        #region PostWorkshopNotifications(WorkshopNotificationsVM model)
        public IResponseDTO PostWorkshopNotifications(WorkshopNotificationsVM model)
        {

            try
            {
                var DbWorkshopNotifications = _mapper.Map<WorkshopNotifications>(model);

                var WorkshopNotifications = _mapper.Map<WorkshopNotificationsVM>(_WorkshopNotificationsRepositroy.Add(DbWorkshopNotifications));

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
