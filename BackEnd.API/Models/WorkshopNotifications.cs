using System;
using System.Collections.Generic;

namespace BackEnd.API.Models
{
    public partial class WorkshopNotifications
    {
        public Guid NotificationId { get; set; }
        public Guid? WorkshopId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Workshop Workshop { get; set; }
    }
}
