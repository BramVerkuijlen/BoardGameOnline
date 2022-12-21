using System.ComponentModel.DataAnnotations;

namespace GameYamWeb.Models
{
    public class AccountModel
    {
        [Required]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Wordt mischien in eigen model geplaatst 
        public string LoginInput { get; set; }
    }
}
