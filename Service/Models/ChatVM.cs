using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.Models
{
    public class ChatVM
    {
        public Guid Messageld { get; set; } = Guid.NewGuid();
        public Guid? CustomerId { get; set; }
        public string Content { get; set; }
        public string DataUrl { get; set; }
        public int Type { get; set; }
        public bool? IsRead { get; set; } = false;
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public Guid? WorkShopId { get; set; }
        public bool? IsCustomer { get; set; }
    }
    public class ResponseChat{
        public Guid? CustomerId { get; set; }
        public string Content { get; set; }
        public string CustomerName { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? WorkShopId { get; set; }
        public int CountUnRead { get; set; }
        public string WorkShopName { get; set; }
        public string ImageUrl { get; set; }
        public int Type { get; set; }

    }
}
