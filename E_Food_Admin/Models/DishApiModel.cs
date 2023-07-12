namespace E_Food_Admin.Models
{
    public class DishApiModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int? VoteRating { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
