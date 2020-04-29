//using BackEnd.DAL.Entities;
using BackEnd.Repositories.Generics;
using BackEnd.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.IServices
{
   public interface IServicesMalfunction
    {
        IResponseDTO PostMalfunction(MalfunctionVM model);
        IResponseDTO GetAllMalfunction();
        IResponseDTO EditMalfunction(MalfunctionVM model);
        IResponseDTO DeleteMalfunction(MalfunctionVM model);
        IResponseDTO GetByIDMalfunction(object id);
    }
}
