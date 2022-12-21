using GameYamWeb.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace GameYamWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService accountService;
        public AccountController(AccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            AccountModel model= new AccountModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(AccountModel model)
        {
            if (accountService.CheckIfUsernameExists(model.Username) || accountService.CheckIfEmailExists(model.Email))
            {
                return RedirectToAction("Register");
            }

            if (!accountService.CheckIfUsernameValid(model.Username))
            {
                return RedirectToAction("Register");
            }

            if (!accountService.CheckIfEmailValid(model.Email))
            {
                return RedirectToAction("Register");
            }

            accountService.CreateAccount(model.Username, model.Email, model.Password);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            AccountModel model = new AccountModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(AccountModel model)
        {
            if (accountService.Login(model.LoginInput, model.Password))
            {
                return RedirectToAction("Index", "Game");
            }

            return RedirectToAction("Login");
        }
    }
}
