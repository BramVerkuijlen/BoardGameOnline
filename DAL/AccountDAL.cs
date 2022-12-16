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
    public class AccountDAL : IAccountDAL
    {
        private readonly string Connectionstring;
        public AccountDAL(dbContext dbContext)
        {
            Connectionstring = dbContext.ConnectionString;
        }

        public void Create(string username, string email, string password)
        {
            if (username == null || email == null || password == null)
            {
                throw new ArgumentNullException("name, email, password");
            }

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("INSERT INTO Account (Username, Email, Password) VALUES(@username, @email, @password)", conn);

                querry.Parameters.AddWithValue("@username", username);
                querry.Parameters.AddWithValue ("email", email);
                querry.Parameters.AddWithValue("password", password);

                querry.ExecuteReader();

                conn.Close();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AccountDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AccountDTO> GetAll()
        {
            List<AccountDTO> accounts = new List<AccountDTO>();

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("SELECT * FROM Account", conn);

                SqlDataReader reader = querry.ExecuteReader();

                while (reader.Read())
                {
                    AccountDTO account= new AccountDTO();

                    account.Id = reader.GetInt32(0);
                    account.Username = reader.GetString(1);
                    account.Email = reader.GetString(2);
                    account.PasswordHashed = reader.GetString(3);

                    accounts.Add(account);
                }

                conn.Close();
            }
            return accounts;
        }

        public AccountDTO GetOnEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            AccountDTO account = new AccountDTO();

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("SELECT * FROM Account WHERE Email = @email", conn);

                querry.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = querry.ExecuteReader();

                if (reader.Read())
                {
                    account.Id = reader.GetInt32(0);
                    account.Username = reader.GetString(1);
                    account.Email = reader.GetString(2);
                    account.PasswordHashed = reader.GetString(3);
                }

                conn.Close();
            }
            return account;
        }

        public AccountDTO GetOnUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }

            AccountDTO account = new AccountDTO();

            using (SqlConnection conn = new SqlConnection(Connectionstring))
            {
                conn.Open();

                SqlCommand querry = new SqlCommand("SELECT * FROM Account WHERE Username = @username", conn);

                querry.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = querry.ExecuteReader();

                if (reader.Read())
                {
                    account.Id = reader.GetInt32(0);
                    account.Username = reader.GetString(1);
                    account.Email = reader.GetString(2);
                    account.PasswordHashed = reader.GetString(3);
                }

                conn.Close();
            }
            return account;
        }

        public void Update(int id, string username, string email, string passwordHashed)
        {
            throw new NotImplementedException();
        }
    }
}
