using Animine.Models;
using JikanDotNet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Animine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> Test()
        {

            try
            {
                // Manually instantiate the AnimeService
                var animeService = new Jikan();

                // Call the service method to get top anime
                var topAnimeResponse = await animeService.GetTopAnimeAsync();

                // Pass the data to the view
                return View(topAnimeResponse.Data);
            }
            catch (Exception ex)
            {
                // Handle exceptions, you can log the error and show an error view
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}
