using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class WorkshopRateVM
    {
        public Guid RateId { get; set; } = Guid.NewGuid();
        public Guid? WorkshopId { get; set; }
        public Guid? CustomerId { get; set; }
        public string Notes { get; set; } = "";
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual CustomerVM Customer { get; set; }
        //public virtual WorkshopVM Workshop { get; set; }
    }
}
