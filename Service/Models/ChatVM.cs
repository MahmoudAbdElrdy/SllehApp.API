using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.Models
{
 public   class ChatVM
    {
        public Guid Messageld { get; set; }
        public Guid? CustomerId { get; set; }
        public string Content { get; set; }
        public string DataUrl { get; set; }
        public int Type { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? WorkShopId { get; set; }
        public string ConnectionId { get; set; }
    }
}
