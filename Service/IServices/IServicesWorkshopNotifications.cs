//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesWorkshopNotifications
    {
        IResponseDTO PostWorkshopNotifications(WorkshopNotificationsVM model);
        IResponseDTO GetAllWorkshopNotifications();
        IResponseDTO EditWorkshopNotifications(WorkshopNotificationsVM model);
        IResponseDTO DeleteWorkshopNotifications(WorkshopNotificationsVM model);
        IResponseDTO GetByIDWorkshopNotifications(object id);
        IResponseDTO GetByWorkshopId(Guid WorkshopId);
    }
}
