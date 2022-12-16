using DTO.Class;
using InterfaceDAL.Interface;
using Logic.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AccountService
    {
        private readonly IAccountDAL accountDAL;
        public AccountService(IAccountDAL _accountDAL)
        {
            accountDAL = _accountDAL;
        }

        public void CreateAccount(string username,string email, string password)
        {
            if (!CheckIfUsernameValid(username) || CheckIfUsernameExists(username))
            {
                throw new ArgumentException("username");
            }

            if (!CheckIfEmailValid(email) || CheckIfEmailExists(email))
            {
                throw new ArgumentException("email");
            }

            string PasswordHash = SecurePasswordHasher.Hash(password);
            
            accountDAL.Create(username, email, PasswordHash);
        }

        public bool Login(string username, string password)
        {
            AccountDTO accountDTO = accountDAL.GetOnUsername(username);

            return SecurePasswordHasher.Verify(password, accountDTO.PasswordHashed);
        }

        public void Update(string username, string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfUsernameExists(string username)
        {
            return accountDAL.GetOnUsername(username) != null;
        }
        public bool CheckIfEmailExists(string email)
        {
            return accountDAL.GetOnEmail(email) != null;
        }

        public bool CheckIfUsernameValid(string username)
        {
            return !username.Any(ch => !char.IsLetterOrDigit(ch));
        }

        public bool CheckIfEmailValid(string email)
        {
            var EmailAtribute = new EmailAddressAttribute();

            return EmailAtribute.IsValid(email);
        }
    }
}
