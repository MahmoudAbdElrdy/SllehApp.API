//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesWorkshopCar
    {
        IResponseDTO PostWorkshopCar(WorkshopCarVM model);
        IResponseDTO GetAllWorkshopCar();
        IResponseDTO GetAllWorkshopCar(Guid WorkShopId);
        IResponseDTO EditWorkshopCar(WorkshopCarVM model);
        IResponseDTO EditWorkshopCar(List<WorkshopCarVM> model);
        IResponseDTO DeleteWorkshopCar(WorkshopCarVM model);
        IResponseDTO GetByIDWorkshopCar(object id);
    }
}
