using Logic.Class;
using System.ComponentModel.DataAnnotations;

namespace GameYamWeb.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public List<Player> FriendList { get; set; }
    }
}
