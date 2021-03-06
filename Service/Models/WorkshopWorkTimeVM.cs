﻿using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class WorkshopWorkTimeVM
    {
        public Guid WorkTimeId { get; set; } = Guid.NewGuid();
        public Guid? WorkshopId { get; set; }
        public int? DayOfWeek { get; set; } = 0;
        public decimal FromTime { get; set; }
        public decimal ToTime { get; set; }
        public bool? IsAvailable { get; set; } = true;
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow.AddHours(3);

        //public virtual WorkshopVM Workshop { get; set; }
    }
}
