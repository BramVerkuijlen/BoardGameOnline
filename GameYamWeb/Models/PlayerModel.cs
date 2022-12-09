using Logic;
using System.ComponentModel.DataAnnotations;

namespace GameYamWeb.Models
{
    public class PlayerModel
    {

        [Required]
        [Display(Name = "id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; }

        public List<PlayerService> FriendList { get; set; }
    }
}
