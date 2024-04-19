
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public FilmController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Film>>> getFilm()
        {
           if (_databaseContext.Film == null)
            {
                return NotFound();
            }
           
            return await _databaseContext.Film.ToListAsync();
         }

        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            if (_databaseContext.Film == null)
            {
                return NotFound();
            }
            var film = await _databaseContext.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return film;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Film>> DeleteFilm(int id)
        {
            if (_databaseContext.Film == null)
            {
                return NotFound();
            }
            var film = await _databaseContext.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            _databaseContext.Film.Remove(film);
            await _databaseContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Film>> PostFilm(Film film)
        {
            if (_databaseContext.Film == null)
            {
                return NotFound();
            }
            
           
            _databaseContext.Film.Add(film);
            await _databaseContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFilm),new {id = film.filmId},film) ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.filmId)
            {
                return BadRequest();
            }
            // update database
            _databaseContext.Entry(film).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }
            return Ok();

        }
    }
    
}
