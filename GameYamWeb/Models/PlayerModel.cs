using Logic;
using System.ComponentModel.DataAnnotations;

namespace GameYamWeb.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "id")]

        public string Nickname { get; set; }
        [Required]
        [Display(Name = "Nickname")]

        public string Picture { get; set; }
        [Required]
        [Display(Name = "Picture")]

        public List<Player> FriendList { get; set; }
    }
}
