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
    public class ChatServices : IServicesChat
    {
        private readonly IGRepository<Chat> _ChatRepositroy;
        private readonly IGRepository<Malfunction> _MalfunctionRepositroy;
        private readonly IGRepository<Features> _FeaturesRepositroy;
        private readonly IUnitOfWork<DB_A57576_SllehAppContext> _unitOfWork;
        private readonly IResponseDTO _response;
        private readonly IMapper _mapper;
        public ChatServices(IGRepository<Chat> Chat, IGRepository<Malfunction> Malfunction, IGRepository<Features> Features,
            IUnitOfWork<DB_A57576_SllehAppContext> unitOfWork, IResponseDTO responseDTO, IMapper mapper)
        {
            _ChatRepositroy = Chat;
            _MalfunctionRepositroy = Malfunction;
            _FeaturesRepositroy = Features;
            _unitOfWork = unitOfWork;
            _response = responseDTO;
            _mapper = mapper;

        }
        public IResponseDTO DeleteChat(ChatVM model)
        {
            try
            {
                var DbChat = _mapper.Map<Chat>(model);
                var entityEntry = _ChatRepositroy.Remove(DbChat);

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
        public IResponseDTO EditChat(ChatVM model)
        {
            try
            {
                var DbChat = _mapper.Map<Chat>(model);
                var entityEntry = _ChatRepositroy.Update(DbChat);
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
        public IResponseDTO GetAllChat()
        {
            try
            {
                var Chats = _ChatRepositroy.GetAll();

                var ChatsList = _mapper.Map<List<ChatVM>>(Chats);
                _response.Data = ChatsList;
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
        public IResponseDTO GetByIDChat(object id)
        {
            try
            {
                var Chats = _ChatRepositroy.Find(id);

                var ChatsList = _mapper.Map<ChatVM>(Chats);
                _response.Data = ChatsList;
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
        public IResponseDTO PostChat(ChatVM model)
        {
            try
            {
                var DbChat = _mapper.Map<Chat>(model);
                var Chat = _mapper.Map<ChatVM>(_ChatRepositroy.Add(DbChat));
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
      
      
    }
  
}
