//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesOrder
    {
        IResponseDTO PostOrder(OrderVM model);
        IResponseDTO GetAllOrder();
        IResponseDTO EditOrder(OrderVM model);
        IResponseDTO DeleteOrder(OrderVM model);
        IResponseDTO GetByIDOrder(object id);
        IResponseDTO GetByCustomerId(Guid? id);
        IResponseDTO GetRunningByWorkshopId(Guid? id);
        IResponseDTO GetByWorkshopId(Guid? id);
    }
}
