using DTO.Class;
using InterfaceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlayerDAL : IPlayerDAL , IPlayerCollectionDAL
    {
        private readonly string Connectionstring;
        public PlayerDAL(dbContext dbContext)
        {
            Connectionstring = dbContext.ConnectionString;
        }

        public List<PlayerDTO> CreatePlayer()
        {
            throw new NotImplementedException();
        }

        public List<PlayerDTO> DeletePlayer()
        {
            throw new NotImplementedException();
        }

        public List<PlayerDTO> DeletePlayer(int id)
        {
            throw new NotImplementedException();
        }

        public List<PlayerDTO> GetAllPlayers()
        {
            List<PlayerDTO> players = new List<PlayerDTO>();

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("SELECT * FROM Player", conn);

                SqlDataReader reader = querry.ExecuteReader();

                while (reader.Read())
                {
                    PlayerDTO player = new PlayerDTO();

                    player.Id = reader.GetInt32(0);
                    player.Nickname = reader.GetString(1);
                    player.Picture = reader.GetString(2);

                    players.Add(player);
                }
            }
            return players;
        }

        public PlayerDTO GetPlayer(int id)
        {
            PlayerDTO player = new PlayerDTO();

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("SELECT * FROM Player WHERE Id = @Id", conn);

                querry.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = querry.ExecuteReader();


                if (reader.Read())
                {
                    player.Id = reader.GetInt32(0);
                    player.Nickname = reader.GetString(1);
                    player.Picture = reader.GetString(2);
                }
                else
                {
                    throw new Exception("Player not found");
                }
            }
            return player;
        }

        public List<PlayerDTO> UpdatePlayer()
        {
            throw new NotImplementedException();
        }

    }
}
