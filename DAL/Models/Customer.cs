using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Chat = new HashSet<Chat>();
            CustomerNotifications = new HashSet<CustomerNotifications>();
            Order = new HashSet<Order>();
            WorkshopRate = new HashSet<WorkshopRate>();
        }

        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Chat> Chat { get; set; }
        public virtual ICollection<CustomerNotifications> CustomerNotifications { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<WorkshopRate> WorkshopRate { get; set; }
    }
}
