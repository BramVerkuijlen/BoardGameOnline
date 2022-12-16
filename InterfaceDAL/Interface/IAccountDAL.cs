using DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL.Interface
{
    public interface IAccountDAL
    {
        public void Update(int id, string username, string email, string passwordHashed);
        public AccountDTO Get(int id);
        public List<AccountDTO> GetAll();
        public AccountDTO GetOnUsername(string username);
        public AccountDTO GetOnEmail(string email);
        public void Delete(int id);
        public void Create(string username, string email, string password);
    }
}
