using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class Chat
    {
        public Guid Messageld { get; set; }
        public Guid? OrderId { get; set; }
        public string Content { get; set; }
        public string DataUrl { get; set; }
        public int Type { get; set; }
        public bool? IsFromCustomer { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Order Order { get; set; }
    }
}
