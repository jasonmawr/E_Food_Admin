using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class SendNotify
    {
        public int SendNotifyId { get; set; }
        public int? Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}
