using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class CustomerVM
    {
        //public Customer()
        //{
        //    CustomerNotifications = new HashSet<CustomerNotifications>();
        //    Order = new HashSet<Order>();
        //    WorkshopRate = new HashSet<WorkshopRate>();
        //}

        public Guid CustomerId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public string Token { get; set; }
        //public virtual ICollection<CustomerNotificationsVM> CustomerNotifications { get; set; }
        //public virtual ICollection<OrderVM> Order { get; set; }
        //public virtual ICollection<WorkshopRateVM> WorkshopRate { get; set; }

    }
}
