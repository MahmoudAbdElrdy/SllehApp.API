//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesCountry
    {
        IResponseDTO PostCountry(CountryVM model);
        IResponseDTO GetAllCountry();
        IResponseDTO EditCountry(CountryVM model);
        IResponseDTO DeleteCountry(CountryVM model);
        IResponseDTO GetByIDCountry(object id);
    }
}
