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
    public class WorkshopFeaturesServices : IServicesWorkshopFeatures
    {
        #region PrivateField
        private readonly IGRepository<WorkshopFeatures> _WorkshopFeaturesRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkshopFeaturesServices(IGRepository<WorkshopFeatures> WorkshopFeatures,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _WorkshopFeaturesRepositroy = WorkshopFeatures;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteWorkshopFeatures(WorkshopFeaturesVM model)
        public IResponseDTO DeleteWorkshopFeatures(WorkshopFeaturesVM model)
        {
            try
            {

                var DbWorkshopFeatures = _mapper.Map<WorkshopFeatures>(model);
                var entityEntry = _WorkshopFeaturesRepositroy.Remove(DbWorkshopFeatures);


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

        #region EditWorkshopFeatures(WorkshopFeaturesVM model)
        public IResponseDTO EditWorkshopFeatures(WorkshopFeaturesVM model)
        {
            try
            {
                var DbWorkshopFeatures = _mapper.Map<WorkshopFeatures>(model);
                var entityEntry = _WorkshopFeaturesRepositroy.Update(DbWorkshopFeatures);


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
        public IResponseDTO EditWorkshopFeatures(List<WorkshopFeaturesVM> model)
        {
            try
            {
                var DbWorkshopFeatures = _mapper.Map<List<WorkshopFeatures>>(model);
            
                var workShopid = DbWorkshopFeatures.FirstOrDefault().WorkshopId;
                var List = _WorkshopFeaturesRepositroy.GetAll(x => x.WorkshopId == workShopid);
                _WorkshopFeaturesRepositroy.RemoveRange(List);
                _unitOfWork.Commit();
                _WorkshopFeaturesRepositroy.AddRange(DbWorkshopFeatures);



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

        #region GetAllWorkshopFeatures()
        public IResponseDTO GetAllWorkshopFeatures()
        {
            try
            {
                var WorkshopFeaturess = _WorkshopFeaturesRepositroy.GetAll();


                var WorkshopFeaturessList = _mapper.Map<List<WorkshopFeaturesVM>>(WorkshopFeaturess);
                _response.Data = WorkshopFeaturessList;
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
        public IResponseDTO GetAllWorkshopFeatures(Guid id)
        {
            try
            {
                var WorkshopFeaturess = _WorkshopFeaturesRepositroy.GetAll(x => x.WorkshopId == id).Select(WorkshopFeatures => new
                {
                    FeatureWorkeshopId = WorkshopFeatures.FeatureWorkeshopId,
                    WorkshopId = WorkshopFeatures.WorkshopId,
                    Notes = WorkshopFeatures.Notes,
                    CreationDate = WorkshopFeatures.CreationDate,
                    FeatureId = WorkshopFeatures.FeatureId,
                    Name = WorkshopFeatures.Feature != null ? WorkshopFeatures.Feature.Name : "",
                }).ToList();


              //  var WorkshopFeaturessList = _mapper.Map<List<WorkshopFeaturesVM>>(WorkshopFeaturess);
                _response.Data = WorkshopFeaturess;
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

        public IResponseDTO GetAllWorkshopFeature()
        {
            try
            {
                var WorkshopFeaturess = _WorkshopFeaturesRepositroy.GetAll().Select(WorkshopFeatures => new
                {
                    FeatureWorkeshopId = WorkshopFeatures.FeatureWorkeshopId,
                    WorkshopId = WorkshopFeatures.WorkshopId,
                    Notes = WorkshopFeatures.Notes,
                    CreationDate = WorkshopFeatures.CreationDate,
                    FeatureId = WorkshopFeatures.FeatureId,
                    Name = WorkshopFeatures.Feature != null ? WorkshopFeatures.Feature.Name : "",
                }).ToList();


                //  var WorkshopFeaturessList = _mapper.Map<List<WorkshopFeaturesVM>>(WorkshopFeaturess);
                _response.Data = WorkshopFeaturess;
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

        #region GetByIDWorkshopFeatures(object id)
        public IResponseDTO GetByIDWorkshopFeatures(object id)
        {
            try
            {
                var WorkshopFeaturess = _WorkshopFeaturesRepositroy.Find(id);


                var WorkshopFeaturessList = _mapper.Map<WorkshopFeaturesVM>(WorkshopFeaturess);
                _response.Data = WorkshopFeaturessList;
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

        #region PostWorkshopFeatures(WorkshopFeaturesVM model)
        public IResponseDTO PostWorkshopFeatures(WorkshopFeaturesVM model)
        {

            try
            {
                var DbWorkshopFeatures = _mapper.Map<WorkshopFeatures>(model);

                var WorkshopFeatures = _mapper.Map<WorkshopFeaturesVM>(_WorkshopFeaturesRepositroy.Add(DbWorkshopFeatures));

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
