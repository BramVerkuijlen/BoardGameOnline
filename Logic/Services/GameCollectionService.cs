using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Class;
using InterfaceDAL.Interface;

namespace Logic
{
    public class GameCollectionService
    {
        private readonly IGameCollectionDAL gameCollectionDAL;
        public GameCollectionService(IGameCollectionDAL _gameCollectionDAL)
        {
            gameCollectionDAL = _gameCollectionDAL;
        }
        public Game Get(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            GameDTO gameDTO = gameCollectionDAL.Get(id);

            Game game = new Game(gameDTO.Id, gameDTO.Name, gameDTO.Description);

            return game;
        }
        public List<Game> GetAll()
        {
            List<GameDTO> gameDTOList = gameCollectionDAL.GetAll();

            List<Game> gameList = new List<Game>();

            foreach (GameDTO gameDTO in gameDTOList)
            {
                Game game = new Game(gameDTO.Id, gameDTO.Name, gameDTO.Description);

                gameList.Add(game);
            }

            return gameList;
        }

        public void Create(string name, string description)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            gameCollectionDAL.Create(name , description);
        }

        public void Delete(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            gameCollectionDAL.Delete(id);
        }
    }
}
