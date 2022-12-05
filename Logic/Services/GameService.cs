using DTO.Class;
using InterfaceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GameService
    {
        private readonly IGameDAL gameDAL;
        public GameService(IGameDAL _gameDAL)
        {
            gameDAL = _gameDAL;
        }
        public void Update(int id, string name, string description)
        {
            gameDAL.Update(id, name, description);
        }
    }
}
