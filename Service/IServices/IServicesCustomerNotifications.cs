//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesCustomerNotifications
    {
        IResponseDTO PostCustomerNotifications(CustomerNotificationsVM model);
        IResponseDTO GetAllCustomerNotifications();
        IResponseDTO EditCustomerNotifications(CustomerNotificationsVM model);
        IResponseDTO DeleteCustomerNotifications(CustomerNotificationsVM model);
        IResponseDTO GetByIDCustomerNotifications(object id);
        IResponseDTO GetByCustomerId(Guid CustomerId);
    }
}
