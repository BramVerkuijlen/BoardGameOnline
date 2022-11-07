using DTO.Class;
using DTO.ResponseObject;
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

        public ResponseObject<PlayerDTO> CreatePlayer()
        {
            throw new NotImplementedException();
        }

        public ResponseObject<PlayerDTO> DeletePlayer()
        {
            throw new NotImplementedException();
        }

        public ResponseObject<PlayerDTO> DeletePlayer(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseObject<PlayerDTO> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public ResponseObject<PlayerDTO> GetPlayer(int id)
        {            ResponseObject<PlayerDTO> responseObject = new ResponseObject<PlayerDTO>();

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("SELECT * FROM Player WHERE Id = @Id", conn);

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

        public ResponseObject<PlayerDTO> UpdatePlayer()
        {
            throw new NotImplementedException();
        }

    }
}
