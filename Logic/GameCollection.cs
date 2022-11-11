using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Class;
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
        public GameDTO Get(int id)
        {
            return gameCollectionDAL.Get(id);
        }
        public List<GameDTO> GetAll()
        {
            return gameCollectionDAL.GetAll();
        }

        public void Create(string name, string desciyption)
        {
            gameCollectionDAL.Create(name , desciyption);
        }

        public void Delete(int id)
        {
            gameCollectionDAL.Delete(id);
        }
    }
}
