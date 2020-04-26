using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class Order
    {
        public Guid OrderId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? WorkshopId { get; set; }
        public string MapLatitude { get; set; }
        public string MapLangitude { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Workshop Workshop { get; set; }
    }
}
