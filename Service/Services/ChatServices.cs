using AutoMapper;
using BackEnd.DAL.Models;
using BackEnd.Repositories.Generics;
using BackEnd.Repositories.UOW;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Service.Services
{
    public class ChatServices : IServicesChat
    {
        #region PrivateField
        private readonly IGRepository<Chat> _ChatRepositroy;
        private readonly IGRepository<Workshop> _WorkshopRepositroy;
        private readonly IGRepository<CustomerNotifications> _CustomerNotificationsRepositroy;
        private readonly IGRepository<WorkshopNotifications> _WorkshopNotificationsRepositroy;
        private readonly IGRepository<Customer> _CustomerRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ChatServices(IGRepository<Chat> Chat, IGRepository<Customer> customer, IGRepository<Workshop> Workshop,
            IGRepository<CustomerNotifications> CustomerNotifications, IGRepository<WorkshopNotifications> WorkshopNotifications,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _ChatRepositroy = Chat;
            _CustomerRepositroy = customer;
            _WorkshopRepositroy = Workshop;
            _CustomerNotificationsRepositroy = CustomerNotifications;
            _WorkshopNotificationsRepositroy = WorkshopNotifications;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteChat(ChatVM model)
        public IResponseDTO DeleteChat(ChatVM model)
        {
            try
            {
                var DbChat = _mapper.Map<Chat>(model);
                var entityEntry = _ChatRepositroy.Remove(DbChat);

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

        #region EditChat(ChatVM model)
        public IResponseDTO EditChat(ChatVM model)
        {
            try
            {
                var DbChat = _mapper.Map<Chat>(model);
                var entityEntry = _ChatRepositroy.Update(DbChat);
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

        #region GetAllChat()
        public IResponseDTO GetAllChat()
        {
            try
            {
                var Chats = _ChatRepositroy.GetAll();

                var ChatsList = _mapper.Map<List<ChatVM>>(Chats);
                _response.Data = ChatsList;
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

        #region GetCustomerByWorkShopId(Guid id)
        public IResponseDTO GetCustomerByWorkShopId(Guid id)
        {
            try
            {//GetCustomerByWorkShopId
                var Chats = _ChatRepositroy.Filter(x=>x.WorkShopId==id).ToList();
                
              
                List<ResponseChat> Wrokshops = new List<ResponseChat>();
                foreach (var customerChat in Chats)
                {
                    if (customerChat.CustomerId != null)
                    {
                        var customerHasChat = _CustomerRepositroy.Find(customerChat.CustomerId);
                        var chat = new ResponseChat();
                        chat.Content = customerChat.Content;
                        chat.CreationDate = customerChat.CreationDate;
                        chat.CountUnRead = _ChatRepositroy.Get(x => x.WorkShopId == id && x.IsRead == false).Count();
                        chat.CustomerName = customerHasChat.Name;
                        chat.ImageUrl = customerHasChat.ImageUrl;
                        chat.CustomerId = customerHasChat.CustomerId;

                        Wrokshops.Add(chat);
                    }


                }
                var result = Wrokshops.GroupBy(x => x.WorkShopId)
                      .Select(x => x.OrderByDescending(y => y.CreationDate).First());

                _response.Data = result.Select(x => new
                {
                    Content = x.Content,
                    CountUnRead = x.CountUnRead,
                    CreationDate = x.CreationDate,
                    CustomerName = x.CustomerName,
                    CustomerId = x.CustomerId,
                    ImageUrl = x.ImageUrl,

                });
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

        #region PostChat(ChatVM model)
        public IResponseDTO PostChat(ChatVM model)
        {
            try
            {
                var DbChat = _mapper.Map<Chat>(model);
                var Chat = _mapper.Map<ChatVM>(_ChatRepositroy.Add(DbChat));
                bool _notification = SendNotification(model);
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

        #region SendNotification(ChatVM model)
        public bool SendNotification(ChatVM model)
        {
            try
            {
                
                var customer = _CustomerRepositroy.GetFirst(x => x.CustomerId == model.CustomerId);
                var workshop = _WorkshopRepositroy.GetFirst(x => x.WorkshopId == model.WorkShopId);
                string _title = "",_message = "",_token="";
                Dictionary<string, object> AdditionalData= new Dictionary<string, object>()
                {
                    { "IsOrder" , false},
                    { "CustomerId" , model.CustomerId},
                    { "WorkshopId" , model.WorkShopId},
                };
                if(model.IsCustomer == true)
                {
                    _title = customer.Name;
                    _message = $"لقد وصلتك رسالة جديدة من  {customer.Name}";
                    _token = workshop.Token;
                    _WorkshopNotificationsRepositroy.Add(_mapper.Map<WorkshopNotifications>(new WorkshopNotificationsVM()
                    {
                        WorkshopId = model.WorkShopId,
                        Content = _message,
                        Title = _title,
                    }));
                }
                else
                {
                    _title = workshop.Name;
                    _token = customer.Token;
                    _message = $"لقد وصلتك رسالة جديدة من  {workshop.Name}";
                    _CustomerNotificationsRepositroy.Add(_mapper.Map <CustomerNotifications>(new CustomerNotificationsVM()
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

        #region GetWorkshopByCustomerId(Guid id)
        public IResponseDTO GetWorkshopByCustomerId(Guid id)
        {
            try
            {//GetCustomerByWorkShopId
                var Chats = _ChatRepositroy.Filter(x => x.CustomerId == id).ToList();
                List<ResponseChat> Wrokshops = new List<ResponseChat>();
                foreach (var WorkShopChat in Chats)
                {
                    if (WorkShopChat.WorkShopId != null)
                    {
                        var WorkShopHasChat = _WorkshopRepositroy.Find(WorkShopChat.WorkShopId);
                        var chat = new ResponseChat();
                        chat.Content = WorkShopChat.Content;
                        chat.CreationDate = WorkShopChat.CreationDate;
                        chat.CountUnRead = _ChatRepositroy.Get(x=>x.CustomerId==id&&x.IsRead==false).Count();
                        chat.WorkShopName = WorkShopHasChat.Name;
                        chat.ImageUrl = WorkShopHasChat.ImageUrl;
                        chat.WorkShopId = WorkShopChat.WorkShopId;

                        Wrokshops.Add(chat);
                    }


                }
                var result = Wrokshops.GroupBy(x => x.WorkShopId)
                      .Select(x => x.OrderByDescending(y => y.CreationDate).First());

                _response.Data = result.Select(x => new
                {
                    Content=x.Content,
                    CountUnRead = x.CountUnRead,
                    CreationDate = x.CreationDate,
                    WorkShopName = x.WorkShopName,
                    WorkShopId = x.WorkShopId,
                    ImageUrl = x.ImageUrl,

                });
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

        #region GetChatByCustomerAndWorkshop(Guid id,Guid id2)
        public IResponseDTO GetChatByCustomerAndWorkshop(Guid id,Guid id2)
        {
            try
            {//GetCustomerByWorkShopId
                var Chats = _ChatRepositroy.Filter(x => x.CustomerId == id &&x.WorkShopId==id2).ToList().OrderByDescending(m => m.CreationDate);
               
               var Wrokshopsist = _mapper.Map<List<ChatVM>>(Chats);
                _response.Data = Wrokshopsist;
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

        #region GetByOrderId(Guid OrderId)
        public IResponseDTO GetByOrderId(Guid OrderId)
        {
            try
            {
                var Chats = _ChatRepositroy.GetAll().Where(x=>x.WorkShopId==OrderId);

                var ChatsList = _mapper.Map<List<ChatVM>>(Chats);
                _response.Data = ChatsList;
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
