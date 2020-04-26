using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class MalfunctionVM
    {
        //public Malfunction()
        //{
        //    WorkshopMalfunction = new HashSet<WorkshopMalfunction>();
        //}

        public Guid MalfunctionId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string Notes { get; set; } = "";
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual ICollection<WorkshopMalfunctionVM> WorkshopMalfunction { get; set; }
    }
}
