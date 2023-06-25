using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class UserNotify
    {
        public int? UserId { get; set; }
        public int? NotifyId { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Notify Notify { get; set; }
        public virtual User User { get; set; }
    }
}
