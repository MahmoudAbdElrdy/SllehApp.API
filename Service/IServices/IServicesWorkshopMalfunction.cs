//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesWorkshopMalfunction
    {
        IResponseDTO PostWorkshopMalfunction(WorkshopMalfunctionVM model);
        IResponseDTO GetAllWorkshopMalfunction();
        IResponseDTO GetAllWorkshopMalfunction(Guid id);
        IResponseDTO GetAllWorkshopMalfunctions();
        IResponseDTO EditWorkshopMalfunction(WorkshopMalfunctionVM model);
        IResponseDTO EditWorkshopMalfunction(List<WorkshopMalfunctionVM> model);
        IResponseDTO DeleteWorkshopMalfunction(WorkshopMalfunctionVM model);
        IResponseDTO GetByIDWorkshopMalfunction(object id);
    }
}
