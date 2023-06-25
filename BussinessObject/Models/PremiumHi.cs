﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class PremiumHi
    {
        public int PremiumId { get; set; }
        public int? UserId { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public int? Status { get; set; }

        public virtual Premium Premium { get; set; }
        public virtual User User { get; set; }
    }
}
