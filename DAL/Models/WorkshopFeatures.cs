using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class WorkshopFeatures
    {
        public Guid FeatureId { get; set; }
        public Guid? WorkshopId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual Workshop Workshop { get; set; }
    }
}
