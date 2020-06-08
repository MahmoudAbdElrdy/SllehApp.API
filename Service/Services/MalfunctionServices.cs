using AutoMapper;
//using BackEnd.DAL.Entities;
using BackEnd.DAL.Models;
using BackEnd.Repositories.Generics;
using BackEnd.Repositories.UOW;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
//using DAL;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Service.Services
{
    public class MalfunctionServices : IServicesMalfunction
    {
        #region PrivateField
        private readonly IGRepository<Malfunction> _MalfunctionRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public MalfunctionServices(IGRepository<Malfunction> Malfunction,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _MalfunctionRepositroy = Malfunction;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteMalfunction(MalfunctionVM model)
        public IResponseDTO DeleteMalfunction(MalfunctionVM model)
        {
            try
            {

                var DbMalfunction = _mapper.Map<Malfunction>(model);
                var entityEntry = _MalfunctionRepositroy.Remove(DbMalfunction);


                int save = _unitOfWork.Commit();

                if (save == 200)
                {
                    _response.Data = null;
                    _response.IsPassed = true;
                    _response.Message = "Ok";
                }
                else
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }
            return _response;
        }
        #endregion

        #region EditMalfunction(MalfunctionVM model)
        public IResponseDTO EditMalfunction(MalfunctionVM model)
        {
            try
            {
                var DbMalfunction = _mapper.Map<Malfunction>(model);
                var entityEntry = _MalfunctionRepositroy.Update(DbMalfunction);


                int save = _unitOfWork.Commit();

                if (save == 200)
                {
                    _response.Data = model;
                    _response.IsPassed = true;
                    _response.Message = "Ok";
                }
                else
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }

            return _response;

        }
        #endregion

        #region GetAllMalfunction()
        public IResponseDTO GetAllMalfunction()
        {
            try
            {
                var Malfunctions = _MalfunctionRepositroy.GetAll();


                var MalfunctionsList = _mapper.Map<List<MalfunctionVM>>(Malfunctions);
                _response.Data = MalfunctionsList;
                _response.IsPassed = true;
                _response.Message = "Done";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }
            return _response;
        }
        #endregion

        #region GetByIDMalfunction(object id)
        public IResponseDTO GetByIDMalfunction(object id)
        {
            try
            {
                var Malfunctions = _MalfunctionRepositroy.Find(id);


                var MalfunctionsList = _mapper.Map<MalfunctionVM>(Malfunctions);
                _response.Data = MalfunctionsList;
                _response.IsPassed = true;
                _response.Message = "Done";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }
            return _response;
        }
        #endregion

        #region PostMalfunction(MalfunctionVM model)
        public IResponseDTO PostMalfunction(MalfunctionVM model)
        {

            try
            {
                var DbMalfunction = _mapper.Map<Malfunction>(model);

                var Malfunction = _mapper.Map<MalfunctionVM>(_MalfunctionRepositroy.Add(DbMalfunction));

                int save = _unitOfWork.Commit();

                if (save == 200)
                {
                    _response.Data = model;
                    _response.IsPassed = true;
                    _response.Message = "Ok";
                }
                else
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }

            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }


            return _response;

        }
        #endregion
    }
}
