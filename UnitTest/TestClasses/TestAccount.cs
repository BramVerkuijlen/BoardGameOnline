using Logic;
using Logic.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnitTest.FakeDALs;

namespace UnitTest.TestClasses
{
    [TestClass]
    public class TestAccount
    {
        [DataRow("test", "test@test.com", "1234")]
        [DataRow("Sylvester", "sylverster@test.com", "jemoeder")]
        [TestMethod]
        public void Create_CreateAccount_CorrectData(string username, string email, string password)
        {
            //arrange
            FakeAccountDAL fakeAccountDAL = new FakeAccountDAL();
            AccountService accountService = new AccountService(fakeAccountDAL);

            //act
            accountService.CreateAccount(username, email, password);

            //assert
            Assert.AreEqual(6, fakeAccountDAL.Accounts.Count());
            Assert.AreEqual(username, fakeAccountDAL.Accounts.Last().Username);
            Assert.AreEqual(email, fakeAccountDAL.Accounts.Last().Email);
            Assert.IsTrue(SecurePasswordHasher.Verify(password, fakeAccountDAL.Accounts.Last().PasswordHashed));
        }

        [DataRow("test@", "test@test.com", "1234")]
        [DataRow("test", "testtest.com", "1234")]
        [DataRow("Peter", "test@test.com", "1234")]
        [DataRow("test", "Peter@gmail.com", "1234")]
        [TestMethod]
        public void Create_CreateAccount_WrongData(string username, string email, string password)
        {
            //arrange
            FakeAccountDAL fakeAccountDAL = new FakeAccountDAL();
            AccountService accountService = new AccountService(fakeAccountDAL);

            //act
            try
            {
                accountService.CreateAccount(username, email, password);

                //assert
                Assert.Fail();
            } catch (ArgumentException) { }            
        }

        [DataRow("Peter", "1234", true)]
        [DataRow("Peter@gmail.com", "1234", true)]
        [DataRow("John.Johnsen@hotmail.com", "2345", true)]
        [DataRow("Piet", "1234", false)]
        [DataRow("Peter@com", "1234", false)]
        [DataRow("John.Johnsen@hotmail.com", "0239", false)]
        [TestMethod]
        public void Login_LoginToAccount(string loginInput, string password, bool expectedOutcome)
        {
            //arrange
            FakeAccountDAL fakeAccountDAL = new FakeAccountDAL();
            AccountService accountService = new AccountService(fakeAccountDAL);

            //act
            var expected = accountService.Login(loginInput, password);

            //assert
            Assert.AreEqual(expectedOutcome, expected);
        }

        [TestMethod]
        public void Update_UpdateAccount()
        {

        }

        [TestMethod]
        public void Delete_DeleteAccount()
        {

        }

        [DataRow("Peter", true)]
        [DataRow("Pieter", false)]
        [TestMethod]
        public void CheckIfUsernameExists_CheckExistingUsername(string username, bool expectedOutcome)
        {
            //arrange
            FakeAccountDAL fakeAccountDAL = new FakeAccountDAL();
            AccountService accountService = new AccountService(fakeAccountDAL);

            //act

            var expected = accountService.CheckIfUsernameExists(username);

            //assert
            Assert.AreEqual(expectedOutcome, expected);
        }

        [DataRow("Peter@gmail.com", true)]
        [DataRow("Piet@gmail.com", false)]
        [TestMethod]
        public void CheckIfEmailExists_CheckExistingEmail(string email, bool expectedOutcome)
        {
            //arrange
            FakeAccountDAL fakeAccountDAL = new FakeAccountDAL();
            AccountService accountService = new AccountService(fakeAccountDAL);

            //act
            var expected = accountService.CheckIfEmailExists(email);

            //assert
            Assert.AreEqual(expectedOutcome, expected);
        }

        [DataRow("peter", true)]
        [DataRow("peter@", false)]
        [DataRow("peter.", false)]
        [DataRow("peter,", false)]
        [DataRow("peter/", false)]
        [DataRow("peter;", false)]
        [DataRow("peter`", false)]
        [DataRow("Peter@gmail.com", false)]
        [TestMethod]
        public void CheckIfUsernameValid_CheckUsername(string username, bool expectedOutcome)
        {
            //arrange
            FakeAccountDAL fakeAccountDAL = new FakeAccountDAL();
            AccountService accountService = new AccountService(fakeAccountDAL);

            //act
            var expected = accountService.CheckIfUsernameValid(username);

            //assert
            Assert.AreEqual(expectedOutcome, expected);
        }

        [DataRow("Peter@gmail.com", true)]
        [DataRow("peter@", false)]
        [DataRow("peter.", false)]
        [DataRow("peter,", false)]
        [DataRow("peter/", false)]
        [DataRow("peter;", false)]
        [DataRow("peter`", false)]
        [DataRow("peter", false)]
        [TestMethod]
        public void CheckIfEmailValid_CheckEmail(string email, bool expectedOutcome)
        {
            //arrange
            FakeAccountDAL fakeAccountDAL = new FakeAccountDAL();
            AccountService accountService = new AccountService(fakeAccountDAL);

            //act
            var expected = accountService.CheckIfEmailValid(email);

            //assert
            Assert.AreEqual(expectedOutcome, expected);
        }
    }
}
