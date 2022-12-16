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

            foreach (PlayerDTO playerDTO in playerDAL.GetAll())
            {
                List<Player> friendlist = new List<Player>();

                Player player = new Player(playerDTO.Id, playerDTO.Nickname, playerDTO.Picture, friendlist);
                
                players.Add(player);
            }

            return players;
        }
        
        public Player GetPlayer(int id)
        {
            PlayerDTO playerDTO = new PlayerDTO();

            playerDTO = playerDAL.Get(id);

            List<Player> friendlist = new List<Player>();

            Player player = new Player(playerDTO.Id, playerDTO.Nickname, playerDTO.Picture, friendlist);

            return player;

        }
    }
}
