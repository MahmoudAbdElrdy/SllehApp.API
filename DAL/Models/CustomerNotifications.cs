using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class CustomerNotifications
    {
        public Guid NotificationId { get; set; }
        public Guid? CustomerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
