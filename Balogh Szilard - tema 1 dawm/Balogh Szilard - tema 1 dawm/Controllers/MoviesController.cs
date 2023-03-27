using Balogh_Szilard___tema_1_dawm.Data;
using Balogh_Szilard___tema_1_dawm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Balogh_Szilard___tema_1_dawm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly MoviesDbContext dbContext;
        public MoviesController(MoviesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            return Ok(await dbContext.Movies.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetMovie([FromRoute] Guid id)
        {
            var movie = await dbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieRequest addMovieRequest)
        {
            var movie = new Movie()
            {
                Id = Guid.NewGuid(),
                Title = addMovieRequest.Title,
                PublicationDate = addMovieRequest.PublicationDate,
                Likes = addMovieRequest.Likes,
                Director = addMovieRequest.Director
            };

            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();

            return Ok(movie);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] Guid id, UpdateMovieRequest updateMovieRequest)
        {
            var movie = dbContext.Movies.Find(id);
            if (movie != null)
            {
                movie.Title = updateMovieRequest.Title;
                movie.Director = updateMovieRequest.Director;
                movie.PublicationDate = updateMovieRequest.PublicationDate;
                movie.Likes = updateMovieRequest.Likes;

                await dbContext.SaveChangesAsync();
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var movie = await dbContext.Movies.FindAsync(id);

            if (movie != null)
            {
                dbContext.Remove(movie);
                await dbContext.SaveChangesAsync();
                return Ok(movie);
            }

            return NotFound();
        }

        //[HttpGet]
        //public IActionResult GetMoviesWithLikes(int likes)
        //{
        //    var teams = dbContext.Movies.Where(t => t.Likes >= likes).ToList();
        //    return Ok(teams);
        //}


    }
}
