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
        public int Id { get; private set; }

        public string Nickname { get; private set; }

        public string Picture { get; private set; }

        private List<Player> _friendList = new List<Player>();
        public IReadOnlyCollection<Player> FriendList
        {
            get
            {
                return _friendList.AsReadOnly();
            }
        }

        public Player(int id, string nickname, string picture, List<Player> friendList)
        {
            Id = id;
            Nickname = nickname;
            Picture = picture;
            _friendList = friendList;
        }
    }
}
