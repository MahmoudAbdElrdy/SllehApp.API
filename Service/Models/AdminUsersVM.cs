using System;
using System.Collections.Generic;

namespace BackEnd.Service.Models
{
    public partial class AdminUsersVM
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Available { get; set; } = true;
    }
}
