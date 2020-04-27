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
    public class WorkshopServices : IServicesWorkshop
    {
        #region PrivateField
        private readonly IGRepository<Workshop> _WorkshopRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkshopServices(IGRepository<Workshop> Workshop,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _WorkshopRepositroy = Workshop;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteWorkshop(WorkshopVM model)
        public IResponseDTO DeleteWorkshop(WorkshopVM model)
        {
            try
            {

                var DbWorkshop = _mapper.Map<Workshop>(model);
                var entityEntry = _WorkshopRepositroy.Remove(DbWorkshop);


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

        #region EditWorkshop(WorkshopVM model)
        public IResponseDTO EditWorkshop(WorkshopVM model)
        {
            try
            {
                var DbWorkshop = _mapper.Map<Workshop>(model);
                var entityEntry = _WorkshopRepositroy.Update(DbWorkshop);


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

        #region GetAllWorkshop()
        public IResponseDTO GetAllWorkshop()
        {
            try
            {
                var Workshops = _WorkshopRepositroy.GetAll();


                var WorkshopsList = _mapper.Map<List<WorkshopVM>>(Workshops);
                _response.Data = WorkshopsList;
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

        #region WorkshopLogin(WorkshopVM model)
        public IResponseDTO WorkshopLogin(WorkshopVM model)
        {
            try
            {
                var res = _WorkshopRepositroy.GetFirst(X => X.Email == model.Email && X.Password == model.Password);
                if(res == null)
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }
                else
                {
                    var DbWorkshop = _mapper.Map<WorkshopVM>(model);
                    _response.Data = DbWorkshop;
                    _response.IsPassed = true;
                    _response.Message = "Ok";
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

        #region GetByIDWorkshop(object id)
        public IResponseDTO GetByIDWorkshop(object id)
        {
            try
            {
                var Workshops = _WorkshopRepositroy.Find(id);


                var WorkshopsList = _mapper.Map<WorkshopVM>(Workshops);
                _response.Data = WorkshopsList;
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

        #region PostWorkshop(WorkshopVM model)
        public IResponseDTO PostWorkshop(WorkshopVM model)
        {

            try
            {
                var DbWorkshop = _mapper.Map<Workshop>(model);

                var Workshop = _mapper.Map<WorkshopVM>(_WorkshopRepositroy.Add(DbWorkshop));

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
        #region
        public IResponseDTO getNearestWorkShops(double MapLatitude, double MapLangitude, string Token)
        {
            try
            {
                var Workshops = _WorkshopRepositroy.GetAll().ToList();


                var WorkshopsList = _mapper.Map<List<WorkshopVM>>(Workshops);
                for (int i=0;i< WorkshopsList.Count;i++)
                {
                    double lat1 = Deg2Rad((double)WorkshopsList[i].MapLangitude);
                    double lat2 = Deg2Rad(MapLangitude);
                    double lon1 = Deg2Rad((double)WorkshopsList[i].MapLatitude);
                    double lon2 = Deg2Rad(MapLatitude);

                    double R = 6371; // km
                    double x = (lon2 - lon1) * Math.Cos((lat1 + lat2) / 2);
                    double y = (lat2 - lat1);
                    double distance = Math.Sqrt(x * x + y * y) * R;
                  

                    

                    if (distance >= 1500000)
                    {
                        WorkshopsList.Remove(WorkshopsList[i]);
                    }
                }
                _response.Data = WorkshopsList;
                _response.IsPassed = true;
                _response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + ex.Message;
            }
            return _response;
        }
        private static double Deg2Rad(double deg)
        {
            return deg * Math.PI / 180;
        }
      
       
        #endregion
    }
}
