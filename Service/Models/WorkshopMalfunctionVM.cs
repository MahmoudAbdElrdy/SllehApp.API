using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class WorkshopMalfunctionVM
    {
        public Guid WorkshopMalfunctionId { get; set; } = Guid.NewGuid();
        public Guid? MalfunctionId { get; set; }
        public Guid? WorkshopId { get; set; }
        public string Notes { get; set; } = "";
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual MalfunctionVM Malfunction { get; set; }
        //public virtual WorkshopVM Workshop { get; set; }
    }
}
