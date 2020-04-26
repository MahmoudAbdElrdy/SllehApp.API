using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class WorkshopRate
    {
        public Guid RateId { get; set; }
        public Guid? WorkshopId { get; set; }
        public Guid? CustomerId { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Workshop Workshop { get; set; }
    }
}
