using Boots_Personal_Otomasyon.BL.Abstract;
using Boots_Personal_Otomasyon.DTO;
using Boots_Personal_Otomasyon.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boots_Personal_Otomasyon.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserBusiness _userService;
        public AccountController(IUserBusiness userBusiness)
        {
            _userService=userBusiness;
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(UserVM user)
        {
            var DbUser = _userService.GetUser(user.UserName, user.Password);
            if (DbUser != null)
            {
                return Redirect("home");
            }
            else
            {
                return View(user);
            }
            
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
