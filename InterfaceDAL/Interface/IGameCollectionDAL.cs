using DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL.Interface
{
    public interface IGameCollectionDAL
    {
        public List<GameDTO> GetAllGames();
    }
}
