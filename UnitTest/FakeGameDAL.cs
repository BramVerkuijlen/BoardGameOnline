using DTO.Class;
using InterfaceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    internal class FakeGameDAL : IGameCollectionDAL , IGameDAL
    {

        // setting up games for the fake database

        public List<GameDTO> Games = new List<GameDTO>
                {
                    new GameDTO { Id = 1 ,Name = "chess", Description = "defeat the opposing king" },
                    new GameDTO { Id = 2 ,Name = "Uno", Description = "Be the first to play all your cards" },
                    new GameDTO { Id = 3 ,Name = "Dos", Description = "Uno with a twist" },
                    new GameDTO { Id = 4 ,Name = "GO"},
                    new GameDTO { Id = 5 ,Name = "catan"}
                };

        public void Create(string name, string description)
        {
            GameDTO gameDTO = new GameDTO();

            gameDTO.Id = Games.Count() + 1;
            gameDTO.Name = name;
            gameDTO.Description = description;

            Games.Add(gameDTO);
        }

        public void Delete(int id)
        {
            Games.RemoveAll(game => game.Id == id);
        }

        public void Update(int id, string name, string description)
        {
            Games.Where(game => game.Id == id).FirstOrDefault().Id = id;
            Games.Where(game => game.Id == id).FirstOrDefault().Name = name;
            Games.Where(game => game.Id == id).FirstOrDefault().Description = description;
        }

        public GameDTO Get(int id)
        {
            return Games.Where(game => game.Id == id).FirstOrDefault();
        }

        public List<GameDTO> GetAll()
        {
            return Games;
        }
    }
}
