using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class OrderVM
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public Guid? CustomerId { get; set; }
        public Guid? WorkshopId { get; set; }
        public decimal? MapLatitude { get; set; }
        public decimal? MapLangitude { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public int? Status { get; set; }

        public virtual CustomerVM Customer { get; set; }
        public virtual WorkshopVM Workshop { get; set; }
    }
}
