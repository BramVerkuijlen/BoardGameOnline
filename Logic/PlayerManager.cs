using DTO.Class;
using InterfaceDAL.Interface;
using InterfaceDAL.ResponseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PlayerManager
    {
        public DALResponseObject<PlayerDTO> GetPlayer(IPlayerManagerDAL playerManagerDAL, int id)
        {
            return playerManagerDAL.GetPlayer(id);
        }
    }
}
