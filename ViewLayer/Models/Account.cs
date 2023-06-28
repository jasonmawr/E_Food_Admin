using System;
using System.Collections.Generic;

#nullable disable

namespace ViewLayer.Models
{
    public class Account
    {      
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Status { get; set; }
        public string Role { get; set; }
        public int? UserId { get; set; }
        public int? ResManagerId { get; set; }       
    }
}
