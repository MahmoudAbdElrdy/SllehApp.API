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
    public class WorkshopMalfunctionServices : IServicesWorkshopMalfunction
    {
        #region PrivateField
        private readonly IGRepository<WorkshopMalfunction> _WorkshopMalfunctionRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkshopMalfunctionServices(IGRepository<WorkshopMalfunction> WorkshopMalfunction,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _WorkshopMalfunctionRepositroy = WorkshopMalfunction;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteWorkshopMalfunction(WorkshopMalfunctionVM model)
        public IResponseDTO DeleteWorkshopMalfunction(WorkshopMalfunctionVM model)
        {
            try
            {

                var DbWorkshopMalfunction = _mapper.Map<WorkshopMalfunction>(model);
                var entityEntry = _WorkshopMalfunctionRepositroy.Remove(DbWorkshopMalfunction);


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

        #region EditWorkshopMalfunction(WorkshopMalfunctionVM model)
        public IResponseDTO EditWorkshopMalfunction(WorkshopMalfunctionVM model)
        {
            try
            {
                var DbWorkshopMalfunction = _mapper.Map<WorkshopMalfunction>(model);
                var entityEntry = _WorkshopMalfunctionRepositroy.Update(DbWorkshopMalfunction);


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
        public IResponseDTO EditWorkshopMalfunction(List<WorkshopMalfunctionVM> model)
        {
            try
            {
                var DbWorkshopMalfunction = _mapper.Map<List<WorkshopMalfunction>>(model);
               
                var workShopid = DbWorkshopMalfunction.FirstOrDefault().WorkshopId;
                var List = _WorkshopMalfunctionRepositroy.GetAll(x => x.WorkshopId == workShopid);
                _WorkshopMalfunctionRepositroy.RemoveRange(List);
                _unitOfWork.Commit();
                _WorkshopMalfunctionRepositroy.AddRange(DbWorkshopMalfunction);
              

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

        #region GetAllWorkshopMalfunction()
        public IResponseDTO GetAllWorkshopMalfunction()
        {
            try
            {
                var WorkshopMalfunctions = _WorkshopMalfunctionRepositroy.GetAll();


                var WorkshopMalfunctionsList = _mapper.Map<List<WorkshopMalfunctionVM>>(WorkshopMalfunctions);
                _response.Data = WorkshopMalfunctionsList;
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
        public IResponseDTO GetAllWorkshopMalfunction(Guid id)
        {
            try
            {
                var WorkshopMalfunctions = _WorkshopMalfunctionRepositroy.GetAll(x => x.WorkshopId == id).Select(WorkshopMalfunction => new
                {
                    WorkshopMalfunctionId = WorkshopMalfunction.WorkshopMalfunctionId,
                    MalfunctionId = WorkshopMalfunction.MalfunctionId,
                    WorkshopId = WorkshopMalfunction.WorkshopId,
                    Notes = WorkshopMalfunction.Notes,
                    CreationDate = WorkshopMalfunction.CreationDate,
                    Name = WorkshopMalfunction.Malfunction != null ? WorkshopMalfunction.Malfunction.Name : "",
                }).ToList();

               // var WorkshopMalfunctionsList = _mapper.Map<List<WorkshopMalfunctionVM>>(WorkshopMalfunctions);
                _response.Data = WorkshopMalfunctions;
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
        public IResponseDTO GetAllWorkshopMalfunctions()
        {
            try
            {
                var WorkshopMalfunctions = _WorkshopMalfunctionRepositroy.GetAll().Select(WorkshopMalfunction => new
                {
                    WorkshopMalfunctionId = WorkshopMalfunction.WorkshopMalfunctionId,
                    MalfunctionId = WorkshopMalfunction.MalfunctionId,
                    WorkshopId = WorkshopMalfunction.WorkshopId,
                    Notes = WorkshopMalfunction.Notes,
                    CreationDate = WorkshopMalfunction.CreationDate,
                    Name = WorkshopMalfunction.Malfunction != null ? WorkshopMalfunction.Malfunction.Name : "",
                }).ToList();
                var result = WorkshopMalfunctions.GroupBy(x => x.MalfunctionId)
                      .Select(x => x.OrderByDescending(y => y.CreationDate).First()).ToList();

                // var WorkshopMalfunctionsList = _mapper.Map<List<WorkshopMalfunctionVM>>(WorkshopMalfunctions);
                _response.Data = result;
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

        #region GetByIDWorkshopMalfunction(object id)
        public IResponseDTO GetByIDWorkshopMalfunction(object id)
        {
            try
            {
                var WorkshopMalfunctions = _WorkshopMalfunctionRepositroy.Find(id);


                var WorkshopMalfunctionsList = _mapper.Map<WorkshopMalfunctionVM>(WorkshopMalfunctions);
                _response.Data = WorkshopMalfunctionsList;
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

        #region PostWorkshopMalfunction(WorkshopMalfunctionVM model)
        public IResponseDTO PostWorkshopMalfunction(WorkshopMalfunctionVM model)
        {

            try
            {
                var DbWorkshopMalfunction = _mapper.Map<WorkshopMalfunction>(model);

                var WorkshopMalfunction = _mapper.Map<WorkshopMalfunctionVM>(_WorkshopMalfunctionRepositroy.Add(DbWorkshopMalfunction));

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
