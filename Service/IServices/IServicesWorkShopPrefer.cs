//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesWorkShopPrefer
    {
        IResponseDTO PostWorkShopPrefer(WorkShopPreferVM model);
        IResponseDTO GetAllWorkShopPrefer();
        IResponseDTO EditWorkShopPrefer(WorkShopPreferVM model);
        IResponseDTO DeleteWorkShopPrefer(WorkShopPreferVM model);
        IResponseDTO GetByIDWorkShopPrefer(object id);
        IResponseDTO GetByCustomerId(Guid? id);
        IResponseDTO GetRunningByWorkshopId(Guid? id);
        IResponseDTO GetByWorkshopId(Guid? id);
        IResponseDTO GetAllWorkShopPreferAdmin();
    }
}
