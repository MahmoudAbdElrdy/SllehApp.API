using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class WorkshopFeaturesVM
    {
        public Guid FeatureId { get; set; } = Guid.NewGuid();
        public Guid? WorkshopId { get; set; }
        public string Name { get; set; } = "";
        public string Notes { get; set; } = "";
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual WorkshopVM Workshop { get; set; }
    }
}
