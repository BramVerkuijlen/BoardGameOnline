using Microsoft.AspNetCore.Mvc;
using Logic;
using GameYamWeb.Models;
using DTO.Class;

namespace GameYamWeb.Controllers
{
    public class GameController : Controller
    {
        private readonly GameCollection gameCollection;
        private readonly Game game;
        public GameController(GameCollection _gameCollection, Game _game)
        {
            gameCollection = _gameCollection;
            game = _game;
        }

        public IActionResult Index(int pg = 1)
        {
            List<GameDTO> games = new List<GameDTO>();

            games = gameCollection.GetAll();

            List<GameModel> gameModelList = new List<GameModel>();

            foreach (var game in games)
            {
                GameModel gameModel = new GameModel();

                gameModel.Id = game.Id;
                gameModel.Name = game.Name;
                gameModel.Description = game.Description;

                gameModelList.Add(gameModel);
            }

            // setting up pager
            const int pageSize = 5;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = gameModelList.Count();

            Pager Pager = new Pager(recsCount, pg, pageSize);

            // getting list entries for the current page
            int recSkip = (pg - 1) * pageSize;

            List<GameModel> data = new List<GameModel>();

            data = gameModelList.Skip(recSkip).Take(Pager.PageSize).ToList();

            // passing pager on to the view
            this.ViewBag.Pager = Pager;

            //return View(playerModelList);

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            GameModel game = new GameModel();

            return View(game);
        }

        [HttpPost]
        public IActionResult Create(GameModel gameModel)
        {
            gameCollection.Create(gameModel.Name, gameModel.Description);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            GameDTO game = gameCollection.Get(id);

            GameModel gameModel = new GameModel();

            gameModel.Id = game.Id;
            gameModel.Name = game.Name;
            gameModel.Description = game.Description;

            return View(gameModel);
        }

        [HttpPost]
        public IActionResult Edit(GameModel gameModel)
        {
            game.Update(gameModel.Id, gameModel.Name, gameModel.Description);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            gameCollection.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
