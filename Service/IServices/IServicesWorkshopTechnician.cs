//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesWorkshopTechnician
    {
        IResponseDTO PostWorkshopTechnician(WorkshopTechnicianVM model);
        IResponseDTO PostWorkshopTechnician(List<WorkshopTechnicianVM> model);
        IResponseDTO GetAllWorkshopTechnician();
        IResponseDTO EditWorkshopTechnician(WorkshopTechnicianVM model);
        IResponseDTO DeleteWorkshopTechnician(WorkshopTechnicianVM model);
        IResponseDTO GetByIDWorkshopTechnician(object id);
    }
}
