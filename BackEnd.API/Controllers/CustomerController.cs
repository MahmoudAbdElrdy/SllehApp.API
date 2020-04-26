using System;
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Private&Constructor
        private readonly IServicesCustomer _CustomerServices;
        public CustomerController(IServicesCustomer CustomerServices)
        {
            _CustomerServices = CustomerServices;
        }
        #endregion

        #region Post: api/Customer/SaveCustomer
        [HttpPost]
        [Route("SaveCustomer")]
        public IResponseDTO postCustomer(CustomerVM CustomerVM)
        {
            var depart = _CustomerServices.PostCustomer(CustomerVM);
            return depart;
        }
        #endregion

        #region Post: api/Customer/CustomerLogin
        [HttpPost]
        [Route("CustomerLogin")]
        public IResponseDTO CustomerLogin(Service.Models.CustomerVM Customer)
        {
            var depart = _CustomerServices.CustomerLogin(Customer);
            return depart;
        }
        #endregion

        #region Put: api/Customer/UpdateCustomer
        [HttpPut]
        [Route("UpdateCustomer")]
        public IResponseDTO UpdateCustomer(CustomerVM CustomerVM)
        {
            var depart = _CustomerServices.EditCustomer(CustomerVM);
            return depart;
        }
        #endregion

        #region Get: api/Customer/GetAllCustomer
        [HttpGet]
        [Route("GetAllCustomer")]
        public IResponseDTO GetAllCustomer()
        {
            var depart = _CustomerServices.GetAllCustomer();
            return depart;
        }
        #endregion

        #region Get: api/Customer/GetCustomerById
        [HttpGet]
        [Route("GetCustomerById")]
        public IResponseDTO GetById(Guid ?id)
        {
            var depart = _CustomerServices.GetByIDCustomer(id);
            return depart;
        }
        #endregion

        #region Delete: api/Customer/RemoveCustomer
        [HttpDelete]
        [Route("RemoveCustomer")]
        public IResponseDTO RemoveCustomer(CustomerVM CustomerVM)
        {
            var depart = _CustomerServices.DeleteCustomer(CustomerVM);
            return depart;
        }
        #endregion
    }
}