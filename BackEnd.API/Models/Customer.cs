using System;
using System.Collections.Generic;

namespace BackEnd.API.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerNotifications = new HashSet<CustomerNotifications>();
            Order = new HashSet<Order>();
            RateWorkshop = new HashSet<RateWorkshop>();
        }

        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string CreationDate { get; set; }

        public virtual ICollection<CustomerNotifications> CustomerNotifications { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<RateWorkshop> RateWorkshop { get; set; }
    }
}
