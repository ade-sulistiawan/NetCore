using JikanDotNet;
using Microsoft.AspNetCore.Mvc;

namespace Animine.Controllers
{
    public class AnimeController : Controller
    {

        readonly Jikan _animeService = new Jikan();

        public async Task<ActionResult> Index()
        {
            try
            {
                var topAnimeResponse = await _animeService.GetTopAnimeAsync();

                return View(topAnimeResponse.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> SearchAnime(string query)
        {
            try
            {
                if (string.IsNullOrEmpty(query)) return View("Error");
                var searchAnimeResponse = await _animeService.SearchAnimeAsync(query);

                return View(searchAnimeResponse.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public async Task<ActionResult> Detail(int id)
        {
            try
            {
                var detailAnimeResponse = await _animeService.GetAnimeFullDataAsync(id);
                return View(detailAnimeResponse.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public async Task<ActionResult> Episode(int id, int page = 1)
        {
            try
            {
                var animeEpisodeResponse = await _animeService.GetAnimeEpisodesAsync(id, page);
                animeEpisodeResponse.Pagination.CurrentPage = page;
                ViewBag.EpisodePagination = animeEpisodeResponse.Pagination;
                ViewBag.AnimeId = id;
                return View(animeEpisodeResponse.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}
