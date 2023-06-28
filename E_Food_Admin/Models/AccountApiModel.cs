namespace E_Food_Admin.Models
{
    public class AccountApiModel
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
