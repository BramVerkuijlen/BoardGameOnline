using System.ComponentModel.DataAnnotations;

namespace GameYamWeb.Models
{
    public class GameModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Descryption")]
        public string Description { get; set; }
    }
}
