using DTO.Class;
using InterfaceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PlayerCollection
    {
        private readonly IPlayerCollectionDAL playerManagerDAL;
        public PlayerCollection(IPlayerCollectionDAL _playerCollectionDAL)
        {
            playerManagerDAL = _playerCollectionDAL;
        }
        public List<PlayerDTO> GetAllPlayers()
        {
            return playerManagerDAL.GetAllPlayers();
        }

        public PlayerDTO GetPlayer(int id)
        {
            return playerManagerDAL.GetPlayer(id);
        }


    }
}
