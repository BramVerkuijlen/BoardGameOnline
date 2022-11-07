using DTO.Class;
using DTO.ResponseObject;
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
        public ResponseObject<PlayerDTO> GetAllPlayers()
        {
            return playerManagerDAL.GetAllPlayers();
        }

        public ResponseObject<PlayerDTO> GetPlayer(int id)
        {
            return playerManagerDAL.GetPlayer(id);
        }


    }
}
