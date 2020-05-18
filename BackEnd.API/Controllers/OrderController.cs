using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesOrder _OrderServices;
        public OrderController(IServicesOrder OrderServices)
        {
            _OrderServices = OrderServices;
        }
        #endregion

        #region Post: api/Order/SaveOrder
        [HttpPost]
        [Route("SaveOrder")]
        public IResponseDTO postOrder(OrderVM OrderVM)
        {
            var depart = _OrderServices.PostOrder(OrderVM);
            return depart;
        }
        #endregion

        #region Put: api/Order/UpdateOrder
        [HttpPut]
        [Route("UpdateOrder")]
        public IResponseDTO UpdateOrder(OrderVM OrderVM)
        {
            var depart = _OrderServices.EditOrder(OrderVM);
            return depart;
        }
        #endregion

        #region Get: api/Order/GetAllOrder
        [HttpGet]
        [Route("GetAllOrder")]
        public IResponseDTO GetAllOrder()
        {
            var depart = _OrderServices.GetAllOrder();
            return depart;
        }
        #endregion

        #region Get: api/Order/GetOrderById
        [HttpGet]
        [Route("GetOrderById")]
        public IResponseDTO GetById(Guid ?id)
        {
            var depart = _OrderServices.GetByIDOrder(id);
            return depart;
        }
        #endregion

        #region Get: api/Order/GetByCustomerId
        [HttpGet]
        [Route("GetByCustomerId")]
        public IResponseDTO GetByCustomerId(Guid? id)
        {
            var depart = _OrderServices.GetByCustomerId(id);
            return depart;
        }
        #endregion

        #region Get: api/Order/GetByWorkshopId
        [HttpGet]
        [Route("GetByWorkshopId")]
        public IResponseDTO GetByWorkshopId(Guid? id)
        {
            var depart = _OrderServices.GetByWorkshopId(id);
            return depart;
        }
        #endregion

        #region Get: api/Order/GetRunningByWorkshopId
        [HttpGet]
        [Route("GetRunningByWorkshopId")]
        public IResponseDTO GetRunningByWorkshopId(Guid? id)
        {
            var depart = _OrderServices.GetByWorkshopId(id);
            return depart;
        }
        #endregion

        #region Delete: api/Order/RemoveOrder
        [HttpDelete]
        [Route("RemoveOrder")]
        public IResponseDTO RemoveOrder(OrderVM OrderVM)
        {
            var depart = _OrderServices.DeleteOrder(OrderVM);
            return depart;
        }
        #endregion
    }
}