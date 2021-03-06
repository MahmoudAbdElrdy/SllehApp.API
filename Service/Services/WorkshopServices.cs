﻿using AutoMapper;
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
        private readonly IGRepository<WorkshopCar> _CarWorkshopRepositroy;
        private readonly IGRepository<City> _CityWorkshopRepositroy;
        private readonly IGRepository<WorkshopMalfunction> _MalfunctionWorkshopRepositroy;
        private readonly IGRepository<WorkshopFeatures> _FeaturesWorkshopRepositroy;
        private readonly IGRepository<WorkshopWorkTime> _WorkTimeWorkshopRepositroy;
        private readonly IGRepository<Workshop> _WorkshopRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public WorkshopServices(IGRepository<Workshop> Workshop, IGRepository<WorkshopCar> Car,
            IGRepository<City> CityWorkshopRepositroy,
             IGRepository<WorkshopMalfunction> Malfunction, IGRepository<WorkshopFeatures> Features,
             IGRepository<WorkshopWorkTime> WorkTimes,

            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _CarWorkshopRepositroy = Car;
            _MalfunctionWorkshopRepositroy = Malfunction;
            _FeaturesWorkshopRepositroy = Features;
            _WorkTimeWorkshopRepositroy = WorkTimes;
            _WorkshopRepositroy = Workshop;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;
            _CityWorkshopRepositroy = CityWorkshopRepositroy;

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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }

            return _response;

        }
        #endregion

        #region UpdateWorkshop(WorkshopSVM model)
        public IResponseDTO UpdateWorkshop(WorkshopSVM model)
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }

            return _response;

        }
        #endregion

        #region UpdateStatus(Guid WorkshopId)
        public IResponseDTO UpdateStatus(Guid WorkshopId)
        {
            try
            {
                var DbWorkshop = _WorkshopRepositroy.Get(x => x.WorkshopId == WorkshopId).FirstOrDefault();
                if (DbWorkshop.IsAvailable != null)
                {
                    DbWorkshop.IsAvailable = !DbWorkshop.IsAvailable;
                }
                else
                {
                    DbWorkshop.IsAvailable = true;
                }
                var entityEntry = _WorkshopRepositroy.Update(DbWorkshop);


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

        #region GetAllWorkshop()
        public IResponseDTO GetAllWorkshop()
        {
            try
            {
                var Workshops = _WorkshopRepositroy.Get(includeProperties: "WorkshopRate,City");


                var WorkshopsList = Workshops.Select(x => new
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
                    Prefer = x.Prefer ,

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
      
        #region GetAllWorkshop()
        public IResponseDTO GetAllWorkshopCity()
        {
            try
            {
                List<CityWorkShop> cityWorkShops = new List<CityWorkShop>();
                var Workshops = _WorkshopRepositroy.Get(x => x.CityId != null);
                List<Guid> CityIds = null;
                CityIds = Workshops.Select(c => (Guid)c.CityId).ToList();
                var WrokshopCity = _CityWorkshopRepositroy.Get(w => CityIds.Contains((Guid)w.CityId)).ToList();
                foreach (var Model in WrokshopCity)
                {
                    var count = Workshops.Count(x => x.CityId == Model.CityId);
                    var city = new CityWorkShop();
                    city.CityName = Model.CityName;
                    city.CityId = Model.CityId;
                    city.WorshopCount = count;
                    cityWorkShops.Add(city);
                }

                _response.Data = cityWorkShops;
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

        #region WorkshopLogin(WorkshopVM model)
        public IResponseDTO WorkshopLogin(WorkshopVM model)
        {
            try
            {
                var res = _WorkshopRepositroy.GetFirst(X => X.Email == model.Email && X.Password == model.Password);
                if (res == null)
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }
                else
                {
                    //var DbWorkshop = _mapper.Map<WorkshopVM>(res);
                    //_response.Data = DbWorkshop;
                    //_response.IsPassed = true;
                    //_response.Message = "Ok";
                    res.Token = model.Token;
                    return EditWorkshop(_mapper.Map<WorkshopVM>(res));
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

        #region updateWorkshopToken(WorkshopVM model)
        public IResponseDTO UpdateWorkshopToken(Guid WorkshopId ,string Token)
        {
            try
            {
                var res = _WorkshopRepositroy.GetFirst(x=>x.WorkshopId==WorkshopId);
                if (res == null)
                {
                    _response.Data = null;
                    _response.IsPassed = false;
                    _response.Message = "Not saved";
                }
                else
                {
                    
                    res.Token = Token;
                    return EditWorkshop(_mapper.Map<WorkshopVM>(res));
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
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
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }


            return _response;

        }


        #endregion

        #region Signup(WorkshopSVM model)
        public IResponseDTO Signup(WorkshopSVM model)
        {

            try
            {
                //var DbWorkshop = _mapper.Map<WorkshopVM>(model);
                //DbWorkshop.WorkshopId = Guid.NewGuid();

                if (model.WorkshopCar != null && model.WorkshopCar.Count > 0)
                {
                    foreach (var WorkshopCar in model.WorkshopCar)
                    {
                        WorkshopCar.WorkshopId = model.WorkshopId;
                        WorkshopCar.WorkshopCarId = Guid.NewGuid();
                    }
                }

                if (model.WorkshopMalfunction != null && model.WorkshopMalfunction.Count > 0)
                {
                    foreach (var WorkshopMalfunction in model.WorkshopMalfunction)
                    {
                        WorkshopMalfunction.WorkshopId = model.WorkshopId;
                        WorkshopMalfunction.WorkshopMalfunctionId = Guid.NewGuid();
                    }
                }

                if (model.WorkshopFeatures != null && model.WorkshopFeatures.Count > 0)
                {
                    foreach (var WorkshopFeatures in model.WorkshopFeatures)
                    {
                        WorkshopFeatures.WorkshopId = model.WorkshopId;
                        WorkshopFeatures.FeatureWorkeshopId = Guid.NewGuid();
                    }
                }

                if (model.WorkshopWorkTime != null && model.WorkshopWorkTime.Count > 0)
                {
                    foreach (var WorkshopWorkTime in model.WorkshopWorkTime)
                    {
                        WorkshopWorkTime.WorkshopId = model.WorkshopId;
                        WorkshopWorkTime.WorkTimeId = Guid.NewGuid();
                    }
                }

                _WorkshopRepositroy.Add(_mapper.Map<Workshop>(model));
                int save = _unitOfWork.Commit();

                if (save == 200)
                {
                    _response.Data = model.WorkshopId;
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

        #region getNearestWorkShops(MapLatitude,MapLangitude,Token)
        public IResponseDTO getNearestWorkShops(double MapLatitude, double MapLangitude, string Token)
        {
            try
            {
                List<Workshop> workshops;
                var WorkshopsList = _WorkshopRepositroy.Get(x => x.MapLangitude != null && x.MapLangitude != null, includeProperties: "WorkshopRate").ToList();

                workshops = WorkshopsList.ToList();
                //var WorkshopsList = _mapper.Map<List<WorkshopVM>>(Workshops);
                for (int i = 0; i < WorkshopsList.Count; i++)
                {
                    //if(WorkshopsList[i].MapLangitude!=null || WorkshopsList[i].MapLatitude != null)
                    {
                        double lat1 = Deg2Rad((double)WorkshopsList[i].MapLangitude);
                        double lat2 = Deg2Rad(MapLangitude);
                        double lon1 = Deg2Rad((double)WorkshopsList[i].MapLatitude);
                        double lon2 = Deg2Rad(MapLatitude);

                        double R = 6371; // km    m 6378137
                        double x = (lon2 - lon1) * Math.Cos((lat1 + lat2) / 2);
                        double y = (lat2 - lat1);
                        double distance = Math.Sqrt(x * x + y * y) * R;


                        System.Diagnostics.Debug.WriteLine($"Name : {WorkshopsList[i].Name} , distance : {distance} ");

                        if (distance >= 15)
                        {
                            workshops.Remove(WorkshopsList[i]);
                        }
                    }

                }
                _response.Data = workshops.Select(x => new
                {
                    Address = x.Address,
                    CreationDate = x.CreationDate,
                    WorkshopId = x.WorkshopId,
                    Name = x.Name,
                    IsTrust = x.IsTrust,
                    ImageUrl = x.ImageUrl,
                    Token = x.Token,
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

                _response.IsPassed = true;
                _response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Message = "Error " + string.Format("{0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
            }
            return _response;
        }
        private static double Deg2Rad(double deg)
        {
            return deg * Math.PI / 180;
        }


        #endregion

        #region GetAllWorkshopDeatalis(Guid workshopid)
        public IResponseDTO GetAllWorkshopDeatalis(Guid workshopid)
        {
            try
            {
                //var Workshops = from WorkShop in _WorkshopRepositroy.Get(m => m.WorkshopId == workshopid, includeProperties: "WorkshopCar,WorkshopCar.Car,WorkshopFeatures,WorkshopFeatures.Feature,WorkshopMalfunction,WorkshopMalfunction.Malfunction,WorkshopTechnician,WorkshopWorkTime,WorkshopRate")
                //                select new
                var Workshops = _WorkshopRepositroy.Get(m => m.WorkshopId == workshopid, includeProperties: "WorkshopCar,WorkshopCar.Car,WorkshopFeatures,WorkshopFeatures.Feature,WorkshopMalfunction,WorkshopMalfunction.Malfunction,WorkshopTechnician,WorkshopWorkTime,WorkshopRate").Select(WorkShop => new
                {
                    WorkshopId = WorkShop.WorkshopId,
                    Address = WorkShop.Address,
                    CreationDate = WorkShop.CreationDate,
                    Email = WorkShop.Email,
                    HasSparePart = WorkShop.HasSparePart,
                    HasWarranty = WorkShop.HasWarranty,
                    ImageUrl = WorkShop.ImageUrl,
                    Info = WorkShop.Info,
                    CityId = WorkShop.CityId,
                    IsAvailable = WorkShop.IsAvailable,
                    IsTrust = WorkShop.IsTrust,
                    MapLangitude = WorkShop.MapLangitude,
                    MapLatitude = WorkShop.MapLatitude,
                    Name = WorkShop.Name,
                    OwnerImage = WorkShop.OwnerImage,
                    OwnerName = WorkShop.OwnerName,
                    Password = "",
                    Phone = WorkShop.Phone,
                    Token = WorkShop.Token,
                    RateCount = WorkShop.WorkshopRate.Where(x => x.WorkshopId == workshopid).ToList().Count,
                    RateAVG = WorkShop.WorkshopRate.ToList().Count > 0 ? WorkShop.WorkshopRate.Average(y => y.Rate) : 0.0m,
                    //WorkshopCar = _mapper.Map<List<WorkshopCarVM>>(WorkShop.WorkshopCar.Where(x => x.WorkshopId == workshopid).ToList()),
                    WorkshopCar = WorkShop.WorkshopCar.Select(WorkshopCar => new
                    {
                        WorkshopCarId = WorkshopCar.WorkshopCarId,
                        CarId = WorkshopCar.CarId,
                        WorkshopId = WorkshopCar.WorkshopId,
                        Notes = WorkshopCar.Notes,
                        CreationDate = WorkshopCar.CreationDate,
                        CarName = WorkshopCar.Car != null ? WorkshopCar.Car.Name : "",
                    }).ToList(),
                    //WorkshopFeatures = _mapper.Map<List<WorkshopFeaturesVM>>(WorkShop.WorkshopFeatures.Where(x => x.WorkshopId == workshopid).ToList()),
                    WorkshopFeatures = WorkShop.WorkshopFeatures.Select(WorkshopFeatures => new
                    {
                        FeatureWorkeshopId = WorkshopFeatures.FeatureWorkeshopId,
                        WorkshopId = WorkshopFeatures.WorkshopId,
                        Notes = WorkshopFeatures.Notes,
                        CreationDate = WorkshopFeatures.CreationDate,
                        FeatureId = WorkshopFeatures.FeatureId,
                        Name = WorkshopFeatures.Feature != null ? WorkshopFeatures.Feature.Name : "",
                    }).ToList(),
                    //WorkshopMalfunction = _mapper.Map<List<WorkshopMalfunctionVM>>(WorkShop.WorkshopMalfunction.Where(x => x.WorkshopId == workshopid).ToList()),
                    WorkshopMalfunction = WorkShop.WorkshopMalfunction.Select(WorkshopMalfunction => new
                    {
                        WorkshopMalfunctionId = WorkshopMalfunction.WorkshopMalfunctionId,
                        MalfunctionId = WorkshopMalfunction.MalfunctionId,
                        WorkshopId = WorkshopMalfunction.WorkshopId,
                        Notes = WorkshopMalfunction.Notes,
                        CreationDate = WorkshopMalfunction.CreationDate,
                        Name = WorkshopMalfunction.Malfunction != null ? WorkshopMalfunction.Malfunction.Name : "",
                    }).ToList(),
                    WorkshopTechnician = _mapper.Map<List<WorkshopTechnicianVM>>(WorkShop.WorkshopTechnician),
                    WorkshopWorkTime = _mapper.Map<List<WorkshopWorkTimeVM>>(WorkShop.WorkshopWorkTime),
                }).FirstOrDefault();


                //var WorkshopsList = _mapper.Map<List<WorkshopVM>>(Workshops);
                _response.Data = Workshops;
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

        #region SearchWorkShop(Data data)
        public IResponseDTO SearchWorkShop(Data data)
        {
            try
            {
                List<Guid> carIds = null;
                List<Guid?> workshopCarIds = null;
                List<Guid> MalfunctionIds = null;
                List<Guid?> workshopmalfunctionIds = null;
                List<Guid> FeatureIds = null;
                List<Guid?> workshopFeatureIds = null;
                bool HasSparePart = data.HasSparePart;
                bool HasWarranty = data.HasWarranty;

                if (data.cars != null)
                {
                    carIds = data.cars.Select(c => c.CarId).ToList();
                    var WrokshopCar = _CarWorkshopRepositroy.GetAll().Where(w => carIds.Contains((Guid)w.CarId));
                    workshopCarIds = WrokshopCar.Select(c => c.WorkshopId).ToList();

                }
                if (data.malfunctions != null)
                {
                    MalfunctionIds = data.malfunctions.Select(c => c.MalfunctionId).ToList();
                    var Wrokshopmalfunction = _MalfunctionWorkshopRepositroy.GetAll().Where(w => MalfunctionIds.Contains((Guid)w.MalfunctionId));
                    workshopmalfunctionIds = Wrokshopmalfunction.Select(c => c.WorkshopId).ToList();

                }
                if (data.Features != null)
                {
                    FeatureIds = data.Features.Select(c => c.FeaturesId).ToList();
                    var WrokshopFeature = _FeaturesWorkshopRepositroy.GetAll().Where(w => FeatureIds.Contains((Guid)w.FeatureId));
                    workshopFeatureIds = WrokshopFeature.Select(c => c.WorkshopId).ToList();

                }

                var predicate = PredicateBuilder.True<Workshop>();
                var oldPredicate = predicate;
                if (carIds != null)
                {
                    if (carIds.Count != 0)
                        predicate = predicate.And(w =>
                                     workshopCarIds.Contains((Guid)w.WorkshopId));
                }
                if (MalfunctionIds != null)
                {
                    if (MalfunctionIds.Count != 0)
                        predicate = predicate.And(w =>
                                 workshopmalfunctionIds.Contains((Guid)w.WorkshopId));
                }
                if (FeatureIds != null)
                {
                    if (FeatureIds.Count != 0)
                        predicate = predicate.And(w =>
                                 workshopFeatureIds.Contains((Guid)w.WorkshopId));
                }


                var result = new List<Workshop>();
                //if (oldPredicate == predicate)
                //{
                //    result = new List<Workshop>();
                //}
                //else
                {
                    predicate = predicate.And(w => w.HasSparePart.Equals(HasSparePart) && w.HasWarranty.Equals(HasWarranty));


                    result = _WorkshopRepositroy.Get(predicate, includeProperties: "WorkshopRate,City").ToList();
                    // result = result.Where(x => x.HasSparePart.Equals(HasSparePart)&&x.HasWarranty.Equals(HasWarranty)).ToList();

                }


                if (result == null)
                {
                    _response.Data = result;
                    _response.IsPassed = true;
                    _response.Message = "Done";
                }
                else
                {
                    //_response.Data =_mapper.Map<List<WorkshopVM>>(result);
                    _response.Data = result.Select(x => new
                    {
                        Address = x.Address,
                        CityId = x.CityId,
                        CreationDate = x.CreationDate,
                        WorkshopId = x.WorkshopId,
                        Name = x.Name,
                        IsTrust = x.IsTrust,
                        ImageUrl = x.ImageUrl,
                        Token = x.Token,
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
                    _response.IsPassed = true;
                    _response.Message = "Done";
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

    #region PredicateBuilder
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

    }
    #endregion
    public class CityWorkShop
    {
        public string CityName { get; set; }
        public int WorshopCount { get; set; }
        public Guid CityId { get; set; }
    }
}
