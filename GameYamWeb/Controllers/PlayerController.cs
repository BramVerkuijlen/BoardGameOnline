using Microsoft.AspNetCore.Mvc;
using GameYamWeb.Models;
using DTO.Class;
using DAL;
using InterfaceDAL.ResponseObject;

namespace GameYamWeb.Controllers
{
    public class PlayerController : Controller
    {
        /* readonly IPlayerManagerDAL PlayerManagerDal;
        public PlayerController(IPlayerManagerDAL playerManagerDal)
        {
            PlayerManagerDal = playerManagerDal;
        }
        */
        public IActionResult Profile()
        {
            PlayerDAL playerDal = new PlayerDAL();

            var response = playerDal.GetPlayer(1);

            PlayerModel playerModel = new PlayerModel();

            playerModel.Id = response.data[1].Id;
            playerModel.Nickname = response.data[1].Nickname;
            playerModel.Picture = response.data[1].Picture;

            return View(playerModel);
        }
    }
}
