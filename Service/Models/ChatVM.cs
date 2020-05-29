using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.Models
{
 public   class ChatVM
    {
        public Guid Messageld { get; set; }
        public Guid? OrderId { get; set; }
        public string Content { get; set; }
        public string DataUrl { get; set; }
        public int Type { get; set; }
        public bool? IsFromCustomer { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
