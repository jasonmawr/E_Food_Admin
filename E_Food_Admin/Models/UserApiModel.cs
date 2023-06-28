namespace E_Food_Admin.Models
{
    public class UserApiModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public bool IsPremium { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
