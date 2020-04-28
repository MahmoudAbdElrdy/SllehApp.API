using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerNotificationsController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesCustomerNotifications _CustomerNotificationsServices;
        public CustomerNotificationsController(IServicesCustomerNotifications CustomerNotificationsServices)
        {
            _CustomerNotificationsServices = CustomerNotificationsServices;
        }
        #endregion

        #region Post: api/CustomerNotifications/SaveCustomerNotifications
        [HttpPost]
        [Route("SaveCustomerNotifications")]
        public IResponseDTO postCustomerNotifications(CustomerNotificationsVM CustomerNotificationsVM)
        {
            var depart = _CustomerNotificationsServices.PostCustomerNotifications(CustomerNotificationsVM);
            return depart;
        }
        #endregion

        #region Post: api/CustomerNotifications/GetByCustomerId
        [HttpGet]
        [Route("GetByCustomerId")]
        public IResponseDTO GetByCustomerId(Guid CustomerId)
        {
            var depart = _CustomerNotificationsServices.GetByCustomerId(CustomerId);
            return depart;
        }
        #endregion

        #region Put: api/CustomerNotifications/UpdateCustomerNotifications
        [HttpPut]
        [Route("UpdateCustomerNotifications")]
        public IResponseDTO UpdateCustomerNotifications(CustomerNotificationsVM CustomerNotificationsVM)
        {
            var depart = _CustomerNotificationsServices.EditCustomerNotifications(CustomerNotificationsVM);
            return depart;
        }
        #endregion

        #region Get: api/CustomerNotifications/GetAllCustomerNotifications
        [HttpGet]
        [Route("GetAllCustomerNotifications")]
        public IResponseDTO GetAllCustomerNotifications()
        {
            var depart = _CustomerNotificationsServices.GetAllCustomerNotifications();
            return depart;
        }
        #endregion

        #region Get: api/CustomerNotifications/GetCustomerNotificationsById
        [HttpGet]
        [Route("GetCustomerNotificationsById")]
        public IResponseDTO GetById(Guid ?id)
        {
            var depart = _CustomerNotificationsServices.GetByIDCustomerNotifications(id);
            return depart;
        }
        #endregion

        #region Delete: api/CustomerNotifications/RemoveCustomerNotifications
        [HttpDelete]
        [Route("RemoveCustomerNotifications")]
        public IResponseDTO RemoveCustomerNotifications(CustomerNotificationsVM CustomerNotificationsVM)
        {
            var depart = _CustomerNotificationsServices.DeleteCustomerNotifications(CustomerNotificationsVM);
            return depart;
        }
        #endregion
    }
}