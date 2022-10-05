using Logic.DTO;
using Logic.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Class
{
    internal class AccountDAL : IAccountDAL, IAccountManagerDAL
    {
        public AccountDTO CreateAccount(string username, string password)
        {
            throw new NotImplementedException();
        }

        public AccountDTO DeleteAccount(int ID)
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetUserByID(int ID)
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetUserByUsername(int ID)
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetUserOnID(int ID)
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetUserOnUsername(int ID)
        {
            throw new NotImplementedException();
        }

        public AccountDTO UpdateAccount(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
