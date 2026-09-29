using Microsoft.AspNetCore.Mvc;
using BestFilms;
using Microsoft.EntityFrameworkCore;

namespace BestFilms.Controllers
{
    public class FilmController : Controller
    {
        private readonly BestFilmsContext _db;

        public FilmController(BestFilmsContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Details(int? i)
        {
            var film = await _db.Films.FirstOrDefaultAsync(film => i == film.Id);
            return View(film);
        }

        public async Task<IActionResult> Index()
        {
            var films = await _db.Films.ToArrayAsync();
            return View(films);
        }
    }
}
