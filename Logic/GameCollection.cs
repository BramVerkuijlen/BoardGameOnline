using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Class;
using DTO.ResponseObject;
using InterfaceDAL.Interface;

namespace Logic
{
    public class GameCollection
    {
        private readonly IGameCollectionDAL gameCollectionDAL;
        public GameCollection(IGameCollectionDAL _gameCollectionDAL)
        {
            gameCollectionDAL = _gameCollectionDAL;
        }
        public ResponseObject<GameDTO> GetAllGames()
        {
            return gameCollectionDAL.GetAllGames();
        }
    }
}
