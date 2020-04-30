using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class WorkshopFeatures
    {
        public Guid FeatureWorkeshopId { get; set; }
        public Guid? WorkshopId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? FeatureId { get; set; }

        public virtual Features Feature { get; set; }
        public virtual Workshop Workshop { get; set; }
    }
}
