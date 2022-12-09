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
    public class GameDAL : IGameDAL
    {
        private readonly string Connectionstring;
        public GameDAL(dbContext dbContext)
        {
            Connectionstring = dbContext.ConnectionString;
        }

        public void Create(string name, string description)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("INSERT INTO Game (Name, Description) VALUES(@name, @description)", conn);

                querry.Parameters.AddWithValue("@name", name);
                if (description != null)
                {
                    querry.Parameters.AddWithValue("@description", description);
                }
                else
                {
                    querry.Parameters.AddWithValue("@description", DBNull.Value);
                }
                
                querry.ExecuteReader();

                conn.Close();
            }
        }

        public GameDTO Get(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            GameDTO game = new GameDTO();

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("SELECT * FROM Game WHERE Id = @Id", conn);

                querry.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = querry.ExecuteReader();

                if (reader.Read())
                {
                    game.Id = reader.GetInt32(0);
                    game.Name = reader.GetString(1);

                    if (!reader.IsDBNull(2))
                    {
                        game.Description = reader.GetString(2);
                    }
                }
                else
                {
                    throw new Exception("Game not found");
                }

                conn.Close();
            }
            return game;
        }

        public List<GameDTO> GetAll()
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

                conn.Close();
            }
            return games;
        }
        public void Update(int id, string name, string description)
        {
            if (id == null || name == null)
            {
                throw new ArgumentNullException("id, name");
            }

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("UPDATE Game SET Name = @name, description = @description WHERE Id = @Id", conn);

                querry.Parameters.AddWithValue("@Id", id);
                querry.Parameters.AddWithValue("@name", name);
                if (description != null)
                {
                    querry.Parameters.AddWithValue("@description", description);
                }
                else
                {
                    querry.Parameters.AddWithValue("@description", DBNull.Value);
                }

                querry.ExecuteReader();

                conn.Close();
            }
        }

        public void Delete(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("DELETE FROM Game WHERE Id = @Id", conn);

                querry.Parameters.AddWithValue("@Id", id);

                querry.ExecuteReader();

                conn.Close();
            }
        }
    }
}
