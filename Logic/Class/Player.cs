using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Class
{
    public class Player
    {
        int ID;

        string Nickname;

        string Picture;

        List<Player> FriendList;

        List<Game> Games;

        List<PlayedGame> playedGames;
    }
}
