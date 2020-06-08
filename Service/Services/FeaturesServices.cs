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
    public class FeaturesServices : IServicesFeatures
    {
        #region PrivateField
        private readonly IGRepository<Features> _FeaturesRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public FeaturesServices(IGRepository<Features> Features,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _FeaturesRepositroy = Features;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteFeatures(FeaturesVM model)
        public IResponseDTO DeleteFeatures(FeaturesVM model)
        {
            try
            {

                var DbFeatures = _mapper.Map<Features>(model);
                var entityEntry = _FeaturesRepositroy.Remove(DbFeatures);


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

        #region EditFeatures(FeaturesVM model)
        public IResponseDTO EditFeatures(FeaturesVM model)
        {
            try
            {
                var DbFeatures = _mapper.Map<Features>(model);
                var entityEntry = _FeaturesRepositroy.Update(DbFeatures);


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

        #region GetAllFeatures()
        public IResponseDTO GetAllFeatures()
        {
            try
            {
                var Featuress = _FeaturesRepositroy.GetAll();


                var FeaturessList = _mapper.Map<List<FeaturesVM>>(Featuress);
                _response.Data = FeaturessList;
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

        #region GetByIDFeatures(object id)
        public IResponseDTO GetByIDFeatures(object id)
        {
            try
            {
                var Featuress = _FeaturesRepositroy.Find(id);


                var FeaturessList = _mapper.Map<FeaturesVM>(Featuress);
                _response.Data = FeaturessList;
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

        #region PostFeatures(FeaturesVM model)
        public IResponseDTO PostFeatures(FeaturesVM model)
        {

            try
            {
                var DbFeatures = _mapper.Map<Features>(model);

                var Features = _mapper.Map<FeaturesVM>(_FeaturesRepositroy.Add(DbFeatures));

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
