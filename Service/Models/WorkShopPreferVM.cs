using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Service.Models
{
  public  class WorkShopPreferVM
    {
        public Guid WorkShopPreferId { get; set; } = Guid.NewGuid();
        public Guid WorkShopId { get; set; }
        public Guid CustomerId { get; set; }
        public bool? Prefer { get; set; }
    }
}
