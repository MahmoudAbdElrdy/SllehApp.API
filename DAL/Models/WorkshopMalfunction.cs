using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class WorkshopMalfunction
    {
        public Guid WorkshopMalfunctionId { get; set; }
        public Guid? MalfunctionId { get; set; }
        public Guid? WorkshopId { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Malfunction Malfunction { get; set; }
        public virtual Workshop Workshop { get; set; }
    }
}
