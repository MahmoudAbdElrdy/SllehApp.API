using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class WorkshopNotificationsVM
    {
        public Guid NotificationId { get; set; } = Guid.NewGuid();
        public Guid? WorkshopId { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public bool? IsRead { get; set; } = false;
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual WorkshopVM Workshop { get; set; }
    }
}
