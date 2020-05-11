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
    public class WorkshopRateServices : IServicesWorkshopRate
    {
        #region PrivateField
        private readonly IGRepository<WorkshopRate> _WorkshopRateRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkshopRateServices(IGRepository<WorkshopRate> WorkshopRate,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _WorkshopRateRepositroy = WorkshopRate;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteWorkshopRate(WorkshopRateVM model)
        public IResponseDTO DeleteWorkshopRate(WorkshopRateVM model)
        {
            try
            {

                var DbWorkshopRate = _mapper.Map<WorkshopRate>(model);
                var entityEntry = _WorkshopRateRepositroy.Remove(DbWorkshopRate);


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
                _response.Message = "Error " + ex.Message;
            }
            return _response;
        }
        #endregion

        #region EditWorkshopRate(WorkshopRateVM model)
        public IResponseDTO EditWorkshopRate(WorkshopRateVM model)
        {
            try
            {
                var DbWorkshopRate = _mapper.Map<WorkshopRate>(model);
                var entityEntry = _WorkshopRateRepositroy.Update(DbWorkshopRate);


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
                _response.Message = "Error " + ex.Message;
            }

            return _response;

        }
        #endregion

        #region GetAllWorkshopRate()
        public IResponseDTO GetAllWorkshopRate()
        {
            try
            {
                var WorkshopRates = _WorkshopRateRepositroy.GetAll();


                var WorkshopRatesList = _mapper.Map<List<WorkshopRateVM>>(WorkshopRates);
                _response.Data = WorkshopRatesList;
                _response.IsPassed = true;
                _response.Message = "Done";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }
            return _response;
        }
        #endregion

        #region GetByIDWorkshopRate(object id)
        public IResponseDTO GetByIDWorkshopRate(object id)
        {
            try
            {
                var WorkshopRates = _WorkshopRateRepositroy.Find(id);


                var WorkshopRatesList = _mapper.Map<WorkshopRateVM>(WorkshopRates);
                _response.Data = WorkshopRatesList;
                _response.IsPassed = true;
                _response.Message = "Done";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }
            return _response;
        }
        #endregion

        #region PostWorkshopRate(WorkshopRateVM model)
        public IResponseDTO PostWorkshopRate(WorkshopRateVM model)
        {

            try
            {
                var DbWorkshopRate = _mapper.Map<WorkshopRate>(model);

                var WorkshopRate = _mapper.Map<WorkshopRateVM>(_WorkshopRateRepositroy.Add(DbWorkshopRate));

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
                _response.Message = "Error " + ex.Message;
            }


            return _response;

        }
        #endregion

        #region GetByCustomerId(Guid? id)
        public IResponseDTO GetByCustomerId(Guid? id)
        {
            try
            {
                var WorkshopRates = _WorkshopRateRepositroy.Get(x => x.CustomerId == id);


                var WorkshopRatesList = _mapper.Map<WorkshopRateVM>(WorkshopRates);
                _response.Data = WorkshopRatesList;
                _response.IsPassed = true;
                _response.Message = "Done";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }
            return _response;
        }
        #endregion

        #region GetByWorkshopId(Guid? id)
        public IResponseDTO GetByWorkshopId(Guid? id)
        {
            try
            {
                var WorkshopRates = from entity in _WorkshopRateRepositroy.Get(x => x.WorkshopId == id)
                                    select new
                                    {
                                        entity.CreationDate,
                                        entity.CustomerId,
                                        entity.Notes,
                                        entity.Rate,
                                        entity.RateId,
                                        entity.WorkshopId,
                                    };


                var WorkshopRatesList = WorkshopRates.ToList();
                _response.Data = WorkshopRatesList;
                _response.IsPassed = true;
                _response.Message = "Done";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }
            return _response;
        }
        #endregion
    }
}
