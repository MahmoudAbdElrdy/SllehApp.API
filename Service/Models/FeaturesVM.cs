using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.Models
{
    public partial class FeaturesVM
    {
        public Guid FeaturesId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);
    }
}
