using System.ComponentModel.DataAnnotations;

namespace GameYamWeb.Models
{
    public class GameModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string description { get; set; }
    }
}
