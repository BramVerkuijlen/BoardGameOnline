using Microsoft.AspNetCore.Mvc;
using Logic;
using GameYamWeb.Models;
using DTO.ResponseObject;
using DTO.Class;

namespace GameYamWeb.Controllers
{
    public class PlayerController : Controller
    {
        private readonly PlayerCollection playerCollection;
        public PlayerController(PlayerCollection _playerCollection)
        {
            playerCollection = _playerCollection;
        }

        public IActionResult Index(int pg=1)
        {
            ResponseObject<PlayerDTO> response = new ResponseObject<PlayerDTO>();

            response = playerCollection.GetAllPlayers();

            if (response.Success)
            {
                List<PlayerModel> playerModelList = new List<PlayerModel>();

                foreach (var player in response.data)
                {
                    PlayerModel playerModel = new PlayerModel();

                    playerModel.Id = player.Id;
                    playerModel.Nickname = player.Nickname;
                    playerModel.Picture = player.Picture;

                    playerModelList.Add(playerModel);
                }

                // setting up pager
                const int pageSize = 10;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recsCount = playerModelList.Count();

                var Pager = new Pager(recsCount, pg, pageSize);

                // getting list entries for the current page
                int recSkip = (pg - 1) * pageSize;

                List<PlayerModel> data = new List<PlayerModel>();

                data = playerModelList.Skip(recSkip).Take(Pager.PageSize).ToList();

                // passing pager on to the view
                this.ViewBag.Pager = Pager; 

                //return View(playerModelList);

                return View(data);
            }

            throw new Exception(response.Message);
        }

        [HttpGet]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        public IActionResult Profile()
        {
            ResponseObject<PlayerDTO> response = new ResponseObject<PlayerDTO>();

            response = playerCollection.GetPlayer(1);

            PlayerModel playerModel = new PlayerModel();

            if (response.Success)
            {
                playerModel.Nickname = response.data[0].Nickname;
                playerModel.Picture = response.data[0].Picture;
            }

            return View(playerModel);
        }
    }
}
