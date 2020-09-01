using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class WorkshopTechnicianVM
    {
        public Guid TechnicianId { get; set; } = Guid.NewGuid();
        public Guid? WorkshopId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; } = "";
        public Microsoft.AspNetCore.Http.IFormFile DataFile { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual WorkshopVM Workshop { get; set; }
    }
}
