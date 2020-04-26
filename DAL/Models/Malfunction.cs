using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class Malfunction
    {
        public Malfunction()
        {
            WorkshopMalfunction = new HashSet<WorkshopMalfunction>();
        }

        public Guid MalfunctionId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<WorkshopMalfunction> WorkshopMalfunction { get; set; }
    }
}
