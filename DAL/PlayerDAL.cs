using DTO.Class;
using InterfaceDAL.Interface;
using InterfaceDAL.ResponseObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlayerDAL : IPlayerDAL , IPlayerManagerDAL
    {
        private string Connectionstring = "connectionstring";

        public DALResponseObject<PlayerDTO> CreatePlayer()
        {
            throw new NotImplementedException();
        }

        public DALResponseObject<PlayerDTO> DeletePlayer()
        {
            throw new NotImplementedException();
        }

        public DALResponseObject<PlayerDTO> DeletePlayer(int id)
        {
            throw new NotImplementedException();
        }

        public DALResponseObject<PlayerDTO> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public DALResponseObject<PlayerDTO> GetPlayer(int id)
        {
            DALResponseObject<PlayerDTO> responseObject = new DALResponseObject<PlayerDTO>();

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", conn);

                querry.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = querry.ExecuteReader();

                if (reader.Read() == true)
                {
                    PlayerDTO player = new PlayerDTO();

                    player.Id = reader.GetInt32(0);
                    player.Nickname = reader.GetString(1);
                    player.Picture = reader.GetString(2);

                    responseObject.Message = "User succesfully got";
                    responseObject.Success = true;
                    responseObject.data.Add(player);
                }
                else
                {
                    responseObject.Message = "User didnt exist";
                    responseObject.Success = false;
                }
            }

            return responseObject;
        }

        public DALResponseObject<PlayerDTO> UpdatePlayer()
        {
            throw new NotImplementedException();
        }
    }
}
