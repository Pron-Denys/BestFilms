using Microsoft.AspNetCore.Mvc;
using BestFilms;
using Microsoft.EntityFrameworkCore;

namespace BestFilms.Controllers
{
    public class FilmController(BestFilmsContext _db, IWebHostEnvironment appEnviroment) : Controller
    {
        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(1_000_000_000)]
        public async Task<IActionResult> Create([Bind("Id, Name, FilmDirector, Genre, Description, Year")] Film film, IFormFile? loadPoster)
        {
            film.Poster = loadPoster?.FileName;
            if (film.Name is null || film.FilmDirector is null || film.Genre is null || film.Description is null || film.Year <= 0 || loadPoster is null) return View(film);
            var absolutePath = Path.Combine(appEnviroment.WebRootPath, "Poster", loadPoster.FileName);
            FileStream stream = new FileStream(absolutePath, FileMode.Create);
            await loadPoster?.CopyToAsync(stream)!;
            stream.Dispose();
            _db.Add(new Film { Name = film.Name, FilmDirector = film.FilmDirector, Genre = film.Genre, Year = film.Year, Poster = loadPoster.FileName, Description = film.Description });
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? i)
        {
            var film = await _db.Films.AsNoTracking().FirstOrDefaultAsync(film => i == film.Id);
            return View(film);
        }

        public async Task<IActionResult> Index()
        {
            var films = await _db.Films.AsNoTracking().ToArrayAsync();
            return View(films);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();
            var film = await _db.Films.FindAsync(id);
            return film is null ? NotFound() : View(film);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(1_000_000_000)]
        public async Task<IActionResult> Edit(int? id, [Bind("Id, Name, FilmDirector, Genre, Poster, Description, Year")] Film film, IFormFile? loadPoster)
        {
            if (id == film.Id && film.Name is not null && film.FilmDirector is not null && film.Genre is not null && film.Description is not null && film.Year > 0)
            {
                if (loadPoster is not null)
                {
                    var absolutePath = Path.Combine(appEnviroment.WebRootPath, "Poster", loadPoster!.FileName);
                    film.Poster = loadPoster.FileName;
                    FileStream stream = new FileStream(absolutePath, FileMode.Create);
                    await loadPoster.CopyToAsync(stream);
                    stream.Dispose();
                }
                try
                {
                    _db.Update(film);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (film.Id == 0) return NotFound();
                    throw;
                }
            }
            return View(film);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();
            var film = await _db.Films.FindAsync(id);
            return film is null ? NotFound() : View(film);
        }

        [HttpPost,  ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id is null) return NotFound();
            var film = await _db.Films.FindAsync(id);
            if (film is null) return NotFound();
            _db.Films.Remove(film);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
