using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class CustomerNotificationsVM
    {
        public Guid NotificationId { get; set; } = Guid.NewGuid();
        public Guid? CustomerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsRead { get; set; } = false;
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual CustomerVM Customer { get; set; }
    }
}
