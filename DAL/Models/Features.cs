using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class Features
    {
        public Features()
        {
            WorkshopFeatures = new HashSet<WorkshopFeatures>();
        }

        public Guid FeaturesId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<WorkshopFeatures> WorkshopFeatures { get; set; }
    }
}
