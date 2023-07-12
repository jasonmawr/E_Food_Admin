using System.ComponentModel.DataAnnotations;
using System;

namespace E_Food_Admin.Models
{
    public class RestaurantApiModel
    {
        public int ResId { get; set; }

        public string Name { get; set; }

        public string District { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        public int? Price { get; set; }

        public string OpenTime { get; set; }

        public int? VoteRating { get; set; }

        public string Description { get; set; }

        public decimal? Lat { get; set; }

        public decimal? Log { get; set; }

        public int? Status { get; set; }

        public bool IsDeleted { get; set; }
    }
}
