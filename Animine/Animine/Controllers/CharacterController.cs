using Microsoft.AspNetCore.Mvc;

namespace Animine.Controllers
{
    public class CharacterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCharacterById()
        {
            return View();
        }

    }
}
