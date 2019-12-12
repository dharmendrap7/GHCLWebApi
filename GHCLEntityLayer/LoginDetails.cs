namespace GHCLEntityLayer
{
    public class LoginDetails
    {
        public int? Id { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActive { get; set; }
        public string UserRole { get; set; }
        public string UserContactNumber { get; set; }
        public string UserName { get; set; }
    }
}
