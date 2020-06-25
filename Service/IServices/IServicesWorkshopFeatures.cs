//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesWorkshopFeatures
    {
        IResponseDTO PostWorkshopFeatures(WorkshopFeaturesVM model);
        IResponseDTO GetAllWorkshopFeatures();
        IResponseDTO GetAllWorkshopFeatures(Guid guid);
        IResponseDTO GetAllWorkshopFeature();
        IResponseDTO EditWorkshopFeatures(WorkshopFeaturesVM model);
        IResponseDTO EditWorkshopFeatures(List<WorkshopFeaturesVM> model);
        IResponseDTO DeleteWorkshopFeatures(WorkshopFeaturesVM model);
        IResponseDTO GetByIDWorkshopFeatures(object id);
    }
}
