using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Chat.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _ChatHubContext;

        private readonly IServicesChat _ChatServices;
     
        public ChatController(IHubContext<ChatHub> chatHubContext, IServicesChat ChatServices)
        {
         //   _chatHubContext = chatHubContext;
            _ChatHubContext = chatHubContext;
            _ChatServices = ChatServices;
        }

        [HttpPost]
        [Route("PostChat")]
        public IResponseDTO PostChat(ChatVM message)
        {
            var depart = _ChatServices.PostChat(message);
          //  _ChatHubContext.Clients.User(message.OrderId.ToString()).SendAsync("ReceiveMessage", message);
            return depart;
        }
        #region Put: api/Chat/UpdateChat

        #region Get: api/Chat/GetAllChat
        [HttpGet]
        [Route("GetByOrderId")]
        public IResponseDTO GetByOrderId(Guid OrderId)
        {
            var depart = _ChatServices.GetByOrderId(OrderId);
            return depart;
        }
        #endregion

        [HttpPut]
        [Route("UpdateChat")]
        public IResponseDTO UpdateChat(ChatVM ChatVM)
        {
            var depart = _ChatServices.EditChat(ChatVM);
            return depart;
        }
        #endregion

        #region Get: api/Chat/GetAllChat
        [HttpGet]
        [Route("GetAllChat")]
        public IResponseDTO GetAllChat()
        {
            var depart = _ChatServices.GetAllChat();
            return depart;
        }
        #endregion

      

        #region Get: api/Chat/GetChatById
        [HttpGet]
        [Route("GetCustomerByWorkShopId")]
        public IResponseDTO GetCustomerByWorkShopId(Guid WorkShopId)
        {
            var depart = _ChatServices.GetCustomerByWorkShopId(WorkShopId);
            return depart;
        }
        #endregion
        #region Get: api/Chat/GetChatById
        [HttpGet]
        [Route("GetWorkshopByCustomerId")]
        public IResponseDTO GetWorkshopByCustomerId(Guid CustomerId)
        {
            var depart = _ChatServices.GetWorkshopByCustomerId(CustomerId);
            return depart;
        }
        #endregion
        #region Get: api/Chat/GetChatById
        [HttpGet]
        [Route("GetChatByCustomerAndWorkshop")]
        public IResponseDTO GetChatByCustomerAndWorkshop(Guid CustomerId,Guid WorkShopId)
        {
            var depart = _ChatServices.GetChatByCustomerAndWorkshop(CustomerId,WorkShopId);
            return depart;
        }
        #endregion

        #region Delete: api/Chat/RemoveChat
        [HttpDelete]
        [Route("RemoveChat")]
        public IResponseDTO RemoveChat(ChatVM ChatVM)
        {
            var depart = _ChatServices.DeleteChat(ChatVM);
            return depart;
        }
        #endregion
       
    }
}