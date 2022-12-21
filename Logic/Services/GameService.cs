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

        public Game Get(int id)
        {
            GameDTO gameDTO = gameDAL.Get(id);

            Game game = new Game(gameDTO.Id, gameDTO.Name, gameDTO.Description);

            return game;
        }

        public List<Game> GetAll()
        {
            List<GameDTO> gameDTOList = gameDAL.GetAll();

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

            gameDAL.Create(name, description);
        }

        public void Delete(int id)
        {
            gameDAL.Delete(id);
        }
    }
}
