//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesWorkshopWorkTime
    {
        IResponseDTO PostWorkshopWorkTime(WorkshopWorkTimeVM model);
        IResponseDTO GetAllWorkshopWorkTime();
        IResponseDTO GetAllWorkshopWorkTime(Guid id);
        IResponseDTO EditWorkshopWorkTime(WorkshopWorkTimeVM model);
        IResponseDTO EditWorkshopWorkTime(List<WorkshopWorkTimeVM> model);
        IResponseDTO DeleteWorkshopWorkTime(WorkshopWorkTimeVM model);
        IResponseDTO GetByIDWorkshopWorkTime(object id);
    }
}
