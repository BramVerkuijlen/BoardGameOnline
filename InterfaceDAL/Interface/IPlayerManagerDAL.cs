using DTO.Class;
using InterfaceDAL.ResponseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL.Interface
{
    public interface IPlayerManagerDAL
    {
        public DALResponseObject<PlayerDTO> GetPlayer(int id);
        public DALResponseObject<PlayerDTO> GetAllPlayers();
        public DALResponseObject<PlayerDTO> DeletePlayer(int id);
        public DALResponseObject<PlayerDTO> CreatePlayer();

    }
}
