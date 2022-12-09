using DTO.Class;
using InterfaceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PlayerService
    {
        private readonly IPlayerDAL playerDAL;
        public PlayerService(IPlayerDAL _playerDAL)
        {
            playerDAL = _playerDAL;
        }
        public List<Player> GetAllPlayers()
        {
            List<Player> players = new List<Player>();

            foreach (PlayerDTO playerDTO in playerDAL.GetAllPlayers())
            {
                Player player = new Player();
                player.Id = playerDTO.Id;
                player.Nickname = playerDTO.Nickname;
                player.Picture = playerDTO.Picture;
                
                players.Add(player);
            }

            return players;
        }
        
        public Player GetPlayer(int id)
        {
            PlayerDTO playerDTO = new PlayerDTO();

            playerDTO = playerDAL.GetPlayer(id);

            Player player = new Player();

            player.Id = playerDTO.Id;
            player.Nickname = playerDTO.Nickname;
            player.Picture = playerDTO.Picture;

            return player;

        }
    }
}
