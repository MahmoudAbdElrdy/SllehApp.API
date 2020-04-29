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
    public class WorkshopWorkTimeServices : IServicesWorkshopWorkTime
    {
        #region PrivateField
        private readonly IGRepository<WorkshopWorkTime> _WorkshopWorkTimeRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkshopWorkTimeServices(IGRepository<WorkshopWorkTime> WorkshopWorkTime,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _WorkshopWorkTimeRepositroy = WorkshopWorkTime;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteWorkshopWorkTime(WorkshopWorkTimeVM model)
        public IResponseDTO DeleteWorkshopWorkTime(WorkshopWorkTimeVM model)
        {
            try
            {

                var DbWorkshopWorkTime = _mapper.Map<WorkshopWorkTime>(model);
                var entityEntry = _WorkshopWorkTimeRepositroy.Remove(DbWorkshopWorkTime);


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

        #region EditWorkshopWorkTime(WorkshopWorkTimeVM model)
        public IResponseDTO EditWorkshopWorkTime(WorkshopWorkTimeVM model)
        {
            try
            {
                var DbWorkshopWorkTime = _mapper.Map<WorkshopWorkTime>(model);
                var entityEntry = _WorkshopWorkTimeRepositroy.Update(DbWorkshopWorkTime);


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

        #region GetAllWorkshopWorkTime()
        public IResponseDTO GetAllWorkshopWorkTime()
        {
            try
            {
                var WorkshopWorkTimes = _WorkshopWorkTimeRepositroy.GetAll();


                var WorkshopWorkTimesList = _mapper.Map<List<WorkshopWorkTimeVM>>(WorkshopWorkTimes);
                _response.Data = WorkshopWorkTimesList;
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

        #region GetByIDWorkshopWorkTime(object id)
        public IResponseDTO GetByIDWorkshopWorkTime(object id)
        {
            try
            {
                var WorkshopWorkTimes = _WorkshopWorkTimeRepositroy.Find(id);


                var WorkshopWorkTimesList = _mapper.Map<WorkshopWorkTimeVM>(WorkshopWorkTimes);
                _response.Data = WorkshopWorkTimesList;
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

        #region PostWorkshopWorkTime(WorkshopWorkTimeVM model)
        public IResponseDTO PostWorkshopWorkTime(WorkshopWorkTimeVM model)
        {

            try
            {
                var DbWorkshopWorkTime = _mapper.Map<WorkshopWorkTime>(model);

                var WorkshopWorkTime = _mapper.Map<WorkshopWorkTimeVM>(_WorkshopWorkTimeRepositroy.Add(DbWorkshopWorkTime));

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
    }
}
