//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesCar
    {
        IResponseDTO PostCar(CarVM model);
        IResponseDTO GetAllCar();
        IResponseDTO EditCar(CarVM model);
        IResponseDTO DeleteCar(CarVM model);
        IResponseDTO GetByIDCar(object id);
    }
}
