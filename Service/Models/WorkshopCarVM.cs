using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class WorkshopCarVM
    {
        public Guid WorkshopCarId { get; set; } = Guid.NewGuid();
        public Guid? CarId { get; set; }
        public Guid? WorkshopId { get; set; }
        public string Notes { get; set; } = "";
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual CarVM Car { get; set; }
        //public virtual WorkshopVM Workshop { get; set; }
    }
}
