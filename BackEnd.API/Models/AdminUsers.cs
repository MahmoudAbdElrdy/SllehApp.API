using System;
using System.Collections.Generic;

namespace BackEnd.API.Models
{
    public partial class AdminUsers
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Available { get; set; }
    }
}
