//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesChat
    {
        IResponseDTO PostChat(ChatVM model);
        IResponseDTO GetAllChat();
     
        IResponseDTO EditChat(ChatVM model);
        IResponseDTO DeleteChat(ChatVM model);
        IResponseDTO GetCustomerByWorkShopId(Guid id);
        IResponseDTO GetWorkshopByCustomerId(Guid id);
        IResponseDTO GetChatByCustomerAndWorkshop(Guid id, Guid id2);
        IResponseDTO GetByOrderId(Guid OrderId);
  //      IResponseDTO GetAllChatSTP();
    }
}
