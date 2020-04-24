using System;
using System.Collections.Generic;

namespace BackEnd.API.Models
{
    public partial class WorkshopTechnician
    {
        public Guid TechnicianId { get; set; }
        public Guid? WorkshopId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Workshop Workshop { get; set; }
    }
}
