using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfase
{
    public interface IAccountManagerDAL
    {
        AccountDTO GetUserByID(int ID);
        AccountDTO GetUserByUsername(int ID);
        AccountDTO CreateAccount(string username , string password);
        AccountDTO DeleteAccount(int ID);

    }
}
