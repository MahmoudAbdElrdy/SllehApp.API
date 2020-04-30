//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesFeatures
    {
        IResponseDTO PostFeatures(FeaturesVM model);
        IResponseDTO GetAllFeatures();
        IResponseDTO EditFeatures(FeaturesVM model);
        IResponseDTO DeleteFeatures(FeaturesVM model);
        IResponseDTO GetByIDFeatures(object id);
    }
}
