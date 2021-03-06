﻿using System;
using System.Collections.Generic;

namespace BackEnd.DAL.Models
{
    public partial class WorkshopWorkTime
    {
        public Guid WorkTimeId { get; set; }
        public Guid? WorkshopId { get; set; }
        public int? DayOfWeek { get; set; }
        public bool? IsAvailable { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal FromTime { get; set; }
        public decimal ToTime { get; set; }

        public virtual Workshop Workshop { get; set; }
    }
}
