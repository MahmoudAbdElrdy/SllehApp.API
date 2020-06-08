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
    public class WorkshopTechnicianServices : IServicesWorkshopTechnician
    {
        #region PrivateField
        private readonly IGRepository<WorkshopTechnician> _WorkshopTechnicianRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkshopTechnicianServices(IGRepository<WorkshopTechnician> WorkshopTechnician,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _WorkshopTechnicianRepositroy = WorkshopTechnician;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteWorkshopTechnician(WorkshopTechnicianVM model)
        public IResponseDTO DeleteWorkshopTechnician(WorkshopTechnicianVM model)
        {
            try
            {

                var DbWorkshopTechnician = _mapper.Map<WorkshopTechnician>(model);
                var entityEntry = _WorkshopTechnicianRepositroy.Remove(DbWorkshopTechnician);


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

        #region EditWorkshopTechnician(WorkshopTechnicianVM model)
        public IResponseDTO EditWorkshopTechnician(WorkshopTechnicianVM model)
        {
            try
            {
                var DbWorkshopTechnician = _mapper.Map<WorkshopTechnician>(model);
                var entityEntry = _WorkshopTechnicianRepositroy.Update(DbWorkshopTechnician);


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

        public IResponseDTO EditWorkshopTechnician(List<WorkshopTechnicianVM> model)
        {
            try
            {
                var DbWorkshopTechnician = _mapper.Map<List<WorkshopTechnician>>(model);
            
                var workShopid = DbWorkshopTechnician.FirstOrDefault().WorkshopId;
                var List = _WorkshopTechnicianRepositroy.GetAll(x => x.WorkshopId == workShopid);
                _WorkshopTechnicianRepositroy.RemoveRange(List);
                _unitOfWork.Commit();
                _WorkshopTechnicianRepositroy.AddRange(DbWorkshopTechnician);

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

        #region GetAllWorkshopTechnician()
        public IResponseDTO GetAllWorkshopTechnician()
        {
            try
            {
                var WorkshopTechnicians = _WorkshopTechnicianRepositroy.GetAll();


                var WorkshopTechniciansList = _mapper.Map<List<WorkshopTechnicianVM>>(WorkshopTechnicians);
                _response.Data = WorkshopTechniciansList;
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
        public IResponseDTO GetAllWorkshopTechnician(Guid id)
        {
            try
            {
                var WorkshopTechnicians = _WorkshopTechnicianRepositroy.GetAll(x=>x.WorkshopId==id);


                var WorkshopTechniciansList = _mapper.Map<List<WorkshopTechnicianVM>>(WorkshopTechnicians);
                _response.Data = WorkshopTechniciansList;
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

        #region GetByIDWorkshopTechnician(object id)
        public IResponseDTO GetByIDWorkshopTechnician(object id)
        {
            try
            {
                var WorkshopTechnicians = _WorkshopTechnicianRepositroy.Find(id);


                var WorkshopTechniciansList = _mapper.Map<WorkshopTechnicianVM>(WorkshopTechnicians);
                _response.Data = WorkshopTechniciansList;
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

        #region PostWorkshopTechnician(WorkshopTechnicianVM model)
        public IResponseDTO PostWorkshopTechnician(WorkshopTechnicianVM model)
        {

            try
            {
                var DbWorkshopTechnician = _mapper.Map<WorkshopTechnician>(model);

                var WorkshopTechnician = _mapper.Map<WorkshopTechnicianVM>(_WorkshopTechnicianRepositroy.Add(DbWorkshopTechnician));

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

        #region PostWorkshopTechnician(WorkshopTechnicianVM model)
        public IResponseDTO PostWorkshopTechnician(List<WorkshopTechnicianVM> model)
        {

            try
            {
                foreach (var Technician in model)
                {
                    var DbWorkshopTechnician = _mapper.Map<WorkshopTechnician>(Technician);
                    _WorkshopTechnicianRepositroy.Add(DbWorkshopTechnician);
                }
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
    }
}
