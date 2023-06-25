using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool IsDeleted { get; set; }
    }
}
