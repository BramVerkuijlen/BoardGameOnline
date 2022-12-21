using DTO.Class;
using InterfaceDAL.Interface;
using Logic.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.FakeDALs
{
    internal class FakeAccountDAL : IAccountDAL
    {
        // setting up Accounts for the fake database

        public List<AccountDTO> Accounts = new List<AccountDTO>
                {
                    new AccountDTO { Id = 1 ,Username = "Peter", Email = "Peter@gmail.com", PasswordHashed = SecurePasswordHasher.Hash("1234") },
                    new AccountDTO { Id = 2 ,Username = "John", Email = "John.Johnsen@hotmail.com", PasswordHashed = SecurePasswordHasher.Hash("2345")},
                    new AccountDTO { Id = 3 ,Username = "Appel", Email = "Apple@taart.nl", PasswordHashed = SecurePasswordHasher.Hash("dhadgausfhuafgydsah")},
                    new AccountDTO { Id = 4 ,Username = "Piet", Email = "Piet.Piraat_203@email.com", PasswordHashed = SecurePasswordHasher.Hash("1")},
                    new AccountDTO { Id = 5 ,Username = "Pjan", Email = "pjan.klaasen@gmail.com", PasswordHashed = SecurePasswordHasher.Hash("dasdysdguhsdifagidfujikfayedi")}
                };

        public void Create(string username, string email, string passwordHashed)
        {
            AccountDTO accountDTO = new AccountDTO();

            accountDTO.Id = Accounts.Count() + 1;
            accountDTO.Username = username;
            accountDTO.Email= email;
            accountDTO.PasswordHashed = passwordHashed;

            Accounts.Add(accountDTO);
        }

        public void Delete(int id)
        {
            Accounts.RemoveAll(game => game.Id == id);
        }

        public void Update(int id, string username, string email, string passwordHashed)
        {
            Accounts.Where(account => account.Id == id).FirstOrDefault().Id = id;
            Accounts.Where(account => account.Id == id).FirstOrDefault().Username = username;
            Accounts.Where(account => account.Id == id).FirstOrDefault().Email = email;
            Accounts.Where(account => account.Id == id).FirstOrDefault().PasswordHashed = passwordHashed;
        }

        public AccountDTO Get(int id)
        {
            return Accounts.Where(account => account.Id == id).FirstOrDefault();
        }

        public List<AccountDTO> GetAll()
        {
            return Accounts;
        }

        public AccountDTO GetOnUsername(string username)
        {
            AccountDTO accountDTO = Accounts.Where(account => account.Username == username).FirstOrDefault();

            if(accountDTO == null)
            {
                accountDTO= new AccountDTO();
            }

            return accountDTO;
        }

        public AccountDTO GetOnEmail(string email)
        {
            AccountDTO accountDTO = Accounts.Where(account => account.Email == email).FirstOrDefault();

            if (accountDTO == null)
            {
                accountDTO = new AccountDTO();
            }

            return accountDTO;
        }
    }
}
