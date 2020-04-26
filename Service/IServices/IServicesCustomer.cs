//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesCustomer
    {
        IResponseDTO PostCustomer(CustomerVM model);
        IResponseDTO GetAllCustomer();
        IResponseDTO EditCustomer(CustomerVM model);
        IResponseDTO DeleteCustomer(CustomerVM model);
        IResponseDTO GetByIDCustomer(object id);
        IResponseDTO CustomerLogin(CustomerVM model);
    }
}
