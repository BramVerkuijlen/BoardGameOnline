﻿using Microsoft.AspNetCore.Mvc;
using Logic;
using GameYamWeb.Models;
using DTO.ResponseObject;
using DTO.Class;

namespace GameYamWeb.Controllers
{
    public class GameController : Controller
    {
        private readonly GameCollection gameCollection;
        public GameController(GameCollection _gameCollection)
        {
            gameCollection = _gameCollection;
        }

        public IActionResult Index(int pg = 1)
        {
            List<GameDTO> games = new List<GameDTO>();

            games = gameCollection.GetAllGames();

            List<GameModel> gameModelList = new List<GameModel>();

            foreach (var game in games)
            {
                GameModel gameModel = new GameModel();

                gameModel.Id = game.Id;
                gameModel.Name = game.Name;
                gameModel.description = game.Description;

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
            Game game = new Game();

            return View(game);
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {


            return RedirectToAction("Index");
        }
    }
}
