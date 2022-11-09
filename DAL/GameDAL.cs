using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Class;
using InterfaceDAL.Interface;

namespace DAL
{
    public class GameDAL : IGameCollectionDAL
    {
        private readonly string Connectionstring;
        public GameDAL(dbContext dbContext)
        {
            Connectionstring = dbContext.ConnectionString;
        }
        public List<GameDTO> GetAllGames()
        {
            List<GameDTO> games = new List<GameDTO>();

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("SELECT * FROM Game", conn);

                SqlDataReader reader = querry.ExecuteReader();

                while (reader.Read())
                {
                    GameDTO game = new GameDTO();

                    game.Id = reader.GetInt32(0);
                    game.Name = reader.GetString(1);

                    if (!reader.IsDBNull(2))
                    {
                        game.Description = reader.GetString(2);
                    }
                    games.Add(game);
                }
            }
            return games;
        }
    }
}
