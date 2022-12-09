using Microsoft.AspNetCore.Mvc;
using Logic;
using GameYamWeb.Models;

namespace GameYamWeb.Controllers
{
    public class GameController : Controller
    {
        private readonly GameService gameService;
        public GameController(GameService _gameService)
        {
            gameService = _gameService;
        }

        public IActionResult Index(int pg = 1)
        {
            List<Game> games = new List<Game>();

            games = gameService.GetAll();

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
            gameService.Create(gameModel.Name, gameModel.Description);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Game game = gameService.Get(id);

            GameModel gameModel = new GameModel();

            gameModel.Id = game.Id;
            gameModel.Name = game.Name;
            gameModel.Description = game.Description;
            
            return View(gameModel);
        }

        [HttpPost]
        public IActionResult Edit(GameModel gameModel)
        {
            gameService.Update(gameModel.Id, gameModel.Name, gameModel.Description);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            gameService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
