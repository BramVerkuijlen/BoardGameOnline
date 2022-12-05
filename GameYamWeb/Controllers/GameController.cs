using Microsoft.AspNetCore.Mvc;
using Logic;
using GameYamWeb.Models;

namespace GameYamWeb.Controllers
{
    public class GameController : Controller
    {
        private readonly GameCollectionService gameCollection;
        private readonly GameService game;
        public GameController(GameCollectionService _gameCollection, GameService _game)
        {
            gameCollection = _gameCollection;
            game = _game;

        }

        public IActionResult Index(int pg = 1)
        {
            List<Game> games = new List<Game>();

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
            const int pageSize = 3;
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
            Game game = gameCollection.Get(id);

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
