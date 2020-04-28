//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesCity
    {
        IResponseDTO PostCity(CityVM model);
        IResponseDTO GetAllCity();
        IResponseDTO GetSaudiCity();
        IResponseDTO EditCity(CityVM model);
        IResponseDTO DeleteCity(CityVM model);
        IResponseDTO GetByIDCity(object id);
  //      IResponseDTO GetAllCitySTP();
    }
}
