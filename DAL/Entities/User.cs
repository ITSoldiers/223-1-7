namespace DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }
    }
}
