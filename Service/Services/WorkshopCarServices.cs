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
    public class WorkshopCarServices : IServicesWorkshopCar
    {
        #region PrivateField
        private readonly IGRepository<WorkshopCar> _WorkshopCarRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkshopCarServices(IGRepository<WorkshopCar> WorkshopCar,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _WorkshopCarRepositroy = WorkshopCar;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteWorkshopCar(WorkshopCarVM model)
        public IResponseDTO DeleteWorkshopCar(WorkshopCarVM model)
        {
            try
            {

                var DbWorkshopCar = _mapper.Map<WorkshopCar>(model);
                var entityEntry = _WorkshopCarRepositroy.Remove(DbWorkshopCar);


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

        #region EditWorkshopCar(WorkshopCarVM model)
        public IResponseDTO EditWorkshopCar(WorkshopCarVM model)
        {
            try
            {
                var DbWorkshopCar = _mapper.Map<WorkshopCar>(model);
                var entityEntry = _WorkshopCarRepositroy.Update(DbWorkshopCar);


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

        #region GetAllWorkshopCar()
        public IResponseDTO GetAllWorkshopCar()
        {
            try
            {
                var WorkshopCars = _WorkshopCarRepositroy.GetAll();


                var WorkshopCarsList = _mapper.Map<List<WorkshopCarVM>>(WorkshopCars);
                _response.Data = WorkshopCarsList;
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

        #region GetByIDWorkshopCar(object id)
        public IResponseDTO GetByIDWorkshopCar(object id)
        {
            try
            {
                var WorkshopCars = _WorkshopCarRepositroy.Find(id);


                var WorkshopCarsList = _mapper.Map<WorkshopCarVM>(WorkshopCars);
                _response.Data = WorkshopCarsList;
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

        #region PostWorkshopCar(WorkshopCarVM model)
        public IResponseDTO PostWorkshopCar(WorkshopCarVM model)
        {

            try
            {
                var DbWorkshopCar = _mapper.Map<WorkshopCar>(model);

                var WorkshopCar = _mapper.Map<WorkshopCarVM>(_WorkshopCarRepositroy.Add(DbWorkshopCar));

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
