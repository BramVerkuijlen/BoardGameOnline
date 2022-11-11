using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Class;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        [DataRow("monopoly","got to get orange")]
        [DataRow("monopoly", null)]
        public void Create_CreateGame(string name, string? description)
        {
            // arrange
            FakeGameDAL fakeGameDAL = new FakeGameDAL();
            GameCollection gameCollection = new GameCollection(fakeGameDAL);

            // act
            gameCollection.Create(name, description);

            // assert
            Assert.AreEqual(6, fakeGameDAL.Games.Count());
            Assert.AreEqual(name, fakeGameDAL.Games.Last().Name);
            Assert.AreEqual(description, fakeGameDAL.Games.Last().Description);
        }

        [TestMethod]
        [DataRow(1, "chess", "defeat the opposing king")]
        [DataRow(4,"GO", null)]
        public void Get_GetGame(int id, string expectedName, string? expectedDescryption)
        {
            // arrange
            FakeGameDAL fakeGameDAL = new FakeGameDAL();
            GameCollection gameCollection = new GameCollection(fakeGameDAL);

            // act
            var expected = gameCollection.Get(id);

            // assert
            Assert.AreEqual(id, expected.Id);
            Assert.AreEqual(expectedName, expected.Name);
            Assert.AreEqual(expectedDescryption, expected.Description);
        }

        [TestMethod]
        public void GetAll_GetAllGames()
        {
            // arrange
            FakeGameDAL fakeGameDAL = new FakeGameDAL();
            GameCollection gameCollection = new GameCollection(fakeGameDAL);

            // act
            var expected = gameCollection.GetAll();

            // assert
            Assert.AreEqual("chess", expected[0].Name);
            Assert.AreEqual("defeat the opposing king", expected[0].Description);

            Assert.AreEqual("Uno", expected[1].Name);
            Assert.AreEqual("Dos", expected[2].Name);

            Assert.AreEqual("GO", expected[3].Name);
            Assert.AreEqual(null, expected[3].Description);

            Assert.AreEqual("catan", expected[4].Name);
        }

        [TestMethod]
        [DataRow(1, "Test", "`Test")]
        [DataRow(2, "diasbfduasbdfyas", null)]
        public void Update_UpdateGame(int id, string name, string? description)
        {
            // arrange
            FakeGameDAL fakeGameDAL = new FakeGameDAL();
            Game game = new Game(fakeGameDAL);

            // act
            game.Update(id, name, description);

            // assert
            Assert.AreEqual(id, fakeGameDAL.Games.Where(game => game.Id == id).FirstOrDefault().Id);
            Assert.AreEqual(name, fakeGameDAL.Games.Where(game => game.Id == id).FirstOrDefault().Name);
            Assert.AreEqual(description, fakeGameDAL.Games.Where(game => game.Description == description).FirstOrDefault().Description);
        }

        [TestMethod]
        [DataRow(3)]
        public void Delete_DeleteGame(int id)
        {
            // arrange
            FakeGameDAL fakeGameDAL = new FakeGameDAL();
            GameCollection gameCollection = new GameCollection(fakeGameDAL);

            // act
            gameCollection.Delete(id);

            // assert
            Assert.AreEqual(4, fakeGameDAL.Games.Count());
        }
    }
}
