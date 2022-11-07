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

        public IActionResult Test()
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
