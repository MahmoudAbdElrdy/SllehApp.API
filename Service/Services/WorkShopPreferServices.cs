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
    public class WorkShopPreferServices : IServicesWorkShopPrefer
    {
        #region PrivateField
        private readonly IGRepository<WorkShopPrefer> _WorkShopPreferRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IGRepository<Workshop> _WorkshopRepositroy;
               private readonly IGRepository<Customer> _CustomerRepositroy;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkShopPreferServices(IGRepository<WorkShopPrefer> WorkShopPrefer, IGRepository<Customer> customer, IGRepository<Workshop> Workshop,
                  IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _WorkShopPreferRepositroy = WorkShopPrefer;
            _unitOfWork = unitOfWork;
            _CustomerRepositroy = customer;
            _WorkshopRepositroy = Workshop;
         
            _response = responseDTO;
            _mapper = mapper;

        }
        #endregion

        #region DeleteWorkShopPrefer(WorkShopPreferVM model)
        public IResponseDTO DeleteWorkShopPrefer(WorkShopPreferVM model)
        {
            try
            {

                var DbWorkShopPrefer = _mapper.Map<WorkShopPrefer>(model);
                var entityEntry = _WorkShopPreferRepositroy.Remove(DbWorkShopPrefer);


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

        #region EditWorkShopPrefer(WorkShopPreferVM model)
        public IResponseDTO EditWorkShopPrefer(WorkShopPreferVM model)
        {
            //try
            //{
            //    int OldStuts = (int)_WorkShopPreferRepositroy.GetFirst(x => x.WorkShopPreferId == model.WorkShopPreferId).Status;
            //    var DbWorkShopPrefer = _mapper.Map<WorkShopPrefer>(model);
            //    var entityEntry = _WorkShopPreferRepositroy.Update(DbWorkShopPrefer);
            //    if (OldStuts != model.Status) 
            //    {
            //        bool _notification = SendNotification(model);
            //    }
            //    int save = _unitOfWork.Commit();

            //    if (save == 200)
            //    {
            //        _response.Data = model;
            //        _response.IsPassed = true;
            //        _response.Message = "Ok";
            //    }
            //    else
            //    {
            //        _response.Data = null;
            //        _response.IsPassed = false;
            //        _response.Message = "Not saved";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _response.Data = null;
            //    _response.IsPassed = false;
            //    _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            //}

            return _response;

        }
        #endregion

       

        #region GetAllWorkShopPrefer()
        public IResponseDTO GetAllWorkShopPreferAdmin()
        {
            try
            {
                var WorkShopPrefers = _WorkShopPreferRepositroy.GetAll().Select(x => new {
                    WorkShopPreferId=x.WorkShopPreferId,
                

                }).ToList();


                //var WorkShopPrefersList = WorkShopPrefers;
                _response.Data = WorkShopPrefers;
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
        public IResponseDTO GetAllWorkShopPrefer()
        {
            try
            {
                var WorkShopPrefers = _WorkShopPreferRepositroy.GetAll();


                var WorkShopPrefersList = _mapper.Map<List<WorkShopPreferVM>>(WorkShopPrefers);
                _response.Data = WorkShopPrefersList;
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

        #region GetByIDWorkShopPrefer(object id)
        public IResponseDTO GetByIDWorkShopPrefer(object id)
        {
            try
            {
                var WorkShopPrefers = _WorkShopPreferRepositroy.Find(id);


                var WorkShopPrefersList = _mapper.Map<WorkShopPreferVM>(WorkShopPrefers);
                _response.Data = WorkShopPrefersList;
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

        #region PostWorkShopPrefer(WorkShopPreferVM model)
        public IResponseDTO PostWorkShopPrefer(WorkShopPreferVM model)
        {

            try
            {
                var DbWorkShopPrefer = _mapper.Map<WorkShopPrefer>(model);

                var WorkShopPrefer = _mapper.Map<WorkShopPreferVM>(_WorkShopPreferRepositroy.Add(DbWorkShopPrefer));

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

        #region GetByCustomerId(Guid? id)
        public IResponseDTO GetByCustomerId(Guid? id)
        {
            try
            {
               // List<CityWorkShop> cityWorkShops = new List<CityWorkShop>();
                var WorkShopPrefer = _WorkShopPreferRepositroy.Get(x => x.CustomerId==id && x.Prefer==true);
                List<Guid> WorkShopIds = null;
                WorkShopIds = WorkShopPrefer.Select(c => (Guid)c.WorkShopId).ToList();
                var Wrokshop = _WorkshopRepositroy.Get(w => WorkShopIds.Contains((Guid)w.WorkshopId)).ToList();

              


                var WorkshopsList = Wrokshop.Select(x => new
                {
                    Address = x.Address,
                    CreationDate = x.CreationDate,
                    WorkshopId = x.WorkshopId,
                    Name = x.Name,
                    IsTrust = x.IsTrust,
                    ImageUrl = x.ImageUrl,
                    Token = x.Token,
                    CityId = x.CityId,
                    CityName = x.City == null ? "" : x.City.CityName,
                    Prefer = x.Prefer,

                    MapLatitude = x.MapLatitude,
                    MapLangitude = x.MapLangitude,
                    Email = x.Email,
                    Password = "",
                    Phone = x.Phone,
                    Info = x.Info,
                    OwnerName = x.OwnerName,
                    OwnerImage = x.OwnerImage,
                    IsAvailable = x.IsAvailable,
                    HasSparePart = x.HasSparePart,
                    HasWarranty = x.HasWarranty,
                    RateCount = x.WorkshopRate.Count,
                    RateAVG = x.WorkshopRate.Count > 0 ? x.WorkshopRate.Average(y => y.Rate) : 0.0m,

                }).ToList();
                _response.Data = WorkshopsList;
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

        #region GetByWorkshopId(Guid? id)
        public IResponseDTO GetByWorkshopId(Guid? id)
        {
            try
            {
                var WorkShopPrefers = _WorkShopPreferRepositroy.Get(x => x.WorkShopPreferId == id,includeProperties: "Customer");


                var WorkShopPrefersList = _mapper.Map<List<WorkShopPreferVM>>(WorkShopPrefers);
                _response.Data = WorkShopPrefersList;
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

        #region GetRunningByWorkshopId(Guid? id)
        public IResponseDTO GetRunningByWorkshopId(Guid? id)
        {
            try
            {
                var WorkShopPrefers = _WorkShopPreferRepositroy.Get(x => x.WorkShopId == id , includeProperties: "Customer");


                var WorkShopPrefersList = _mapper.Map<List<WorkShopPreferVM>>(WorkShopPrefers);
                _response.Data = WorkShopPrefersList;
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
    }
}
