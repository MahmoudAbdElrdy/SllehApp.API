//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesWorkshop
    {
        IResponseDTO PostWorkshop(WorkshopVM model);
        IResponseDTO GetAllWorkshop();
        IResponseDTO EditWorkshop(WorkshopVM model);
        IResponseDTO DeleteWorkshop(WorkshopVM model);
        IResponseDTO GetByIDWorkshop(object id);
        IResponseDTO WorkshopLogin(WorkshopVM model);
        IResponseDTO getNearestWorkShops(double MapLatitude,double MapLangitude,string Token );
        IResponseDTO GetAllWorkshopDeatalis(Guid workshopid);

    }
}
