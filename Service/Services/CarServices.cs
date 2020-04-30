using AutoMapper;
using BackEnd.DAL.Models;
using BackEnd.Repositories.Generics;
using BackEnd.Repositories.UOW;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Service.Services
{
    public class CarServices : IServicesCar
    {
        private readonly IGRepository<Car> _CarRepositroy;
        private readonly IGRepository<Malfunction> _MalfunctionRepositroy;
        private readonly IGRepository<Features> _FeaturesRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        public CarServices(IGRepository<Car> Car, IGRepository<Malfunction> Malfunction, IGRepository<Features> Features,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _CarRepositroy = Car;
            _MalfunctionRepositroy = Malfunction;
            _FeaturesRepositroy = Features;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        public IResponseDTO DeleteCar(CarVM model)
        {
            try
            {
                var DbCar = _mapper.Map<Car>(model);
                var entityEntry = _CarRepositroy.Remove(DbCar);

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
        public IResponseDTO EditCar(CarVM model)
        {
            try
            {
                var DbCar = _mapper.Map<Car>(model);
                var entityEntry = _CarRepositroy.Update(DbCar);
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
        public IResponseDTO GetAllCar()
        {
            try
            {
                var Cars = _CarRepositroy.GetAll();

                var CarsList = _mapper.Map<List<CarVM>>(Cars);
                _response.Data = CarsList;
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
        public IResponseDTO GetByIDCar(object id)
        {
            try
            {
                var Cars = _CarRepositroy.Find(id);

                var CarsList = _mapper.Map<CarVM>(Cars);
                _response.Data = CarsList;
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
        public IResponseDTO PostCar(CarVM model)
        {
            try
            {
                var DbCar = _mapper.Map<Car>(model);
                var Car = _mapper.Map<CarVM>(_CarRepositroy.Add(DbCar));
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
        public IResponseDTO GetAllData()
        {
            try
            {
                var Cars = _CarRepositroy.GetAll();
                var malfunctions = _MalfunctionRepositroy.GetAll();
                var features = _FeaturesRepositroy.GetAll();

                var CarsList = _mapper.Map<List<CarVM>>(Cars);
                var malfunctionList = _mapper.Map<List<MalfunctionVM>>(malfunctions);
                var featuresList = _mapper.Map<List<FeaturesVM>>(features);
                Data data = new Data();
                data.cars = CarsList;
                data.Features = featuresList;
                data.malfunctions = malfunctionList;
                _response.Data = data;
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
    }
   public class Data
    {
        public List<CarVM> cars { get; set; }
        public List<MalfunctionVM> malfunctions { get; set; }
        public List<FeaturesVM> Features { get; set; }

    } 
}
