using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic
{
    public class Player
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public string Picture { get; set; }

        public List<Player> FriendList { get; set; }
    }
}
