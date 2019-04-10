namespace ASP_API_101.Models
{
    public class Login
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Login(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}