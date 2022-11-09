using DTO.Class;
using DTO.ResponseObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL.Interface
{
    public interface IGameCollectionDAL
    {
        public ResponseObject<GameDTO> GetAllGames();
    }
}
