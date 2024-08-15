using JikanDotNet;
using Microsoft.AspNetCore.Mvc;

namespace Animine.Controllers
{
    public class MangaController : Controller
    {
        readonly Jikan _animeService = new Jikan();

        public async Task<ActionResult> Index()
        {
            try
            {
                var topMangaResponse = await _animeService.GetTopMangaAsync();

                return View(topMangaResponse.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}
