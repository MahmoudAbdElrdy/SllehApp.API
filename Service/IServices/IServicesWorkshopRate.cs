//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesWorkshopRate
    {
        IResponseDTO PostWorkshopRate(WorkshopRateVM model);
        IResponseDTO GetAllWorkshopRate();
        IResponseDTO EditWorkshopRate(WorkshopRateVM model);
        IResponseDTO DeleteWorkshopRate(WorkshopRateVM model);
        IResponseDTO GetByIDWorkshopRate(object id);
        IResponseDTO GetByCustomerId(Guid? id);
        IResponseDTO GetByWorkshopId(Guid? id);
    }
}
