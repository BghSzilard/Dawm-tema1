using Balogh_Szilard___tema_1_dawm.Data;
using Balogh_Szilard___tema_1_dawm.Models;
using Balogh_Szilard___tema_1_dawm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Balogh_Szilard___tema_1_dawm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly MoviesService movieService;
        public MoviesController(MoviesService movieService)
        {
            this.movieService = movieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMovie(Guid id)
        {
            var movie = await movieService.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieRequest addMovieRequest)
        {
            var movie = await movieService.AddMovie(addMovieRequest);
            return Ok(movie);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateMovie(Guid id, UpdateMovieRequest updateMovieRequest)
        {
            var movie = await movieService.UpdateMovie(id, updateMovieRequest);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var movie = await movieService.DeleteMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        //[HttpGet]
        //public IActionResult GetMoviesWithLikes(int likes)
        //{
        //    var teams = dbContext.Movies.Where(t => t.Likes >= likes).ToList();
        //    return Ok(teams);
        //}


    }
}
