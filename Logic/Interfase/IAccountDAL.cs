using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfase
{
    public interface IAccountDAL
    {
        AccountDTO UpdateAccount(int ID);
    }
}
