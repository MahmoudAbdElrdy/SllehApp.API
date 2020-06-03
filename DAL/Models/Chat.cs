using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class Chat
    {
        public Guid Messageld { get; set; }
        public Guid? CustomerId { get; set; }
        public string Content { get; set; }
        public string DataUrl { get; set; }
        public int Type { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? WorkShopId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Workshop WorkShop { get; set; }
    }
}
