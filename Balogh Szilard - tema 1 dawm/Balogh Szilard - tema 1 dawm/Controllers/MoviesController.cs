using Balogh_Szilard___tema_1_dawm.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllMovies()
        {
            return Ok(dbContext.Movies.ToList());
        }

        //[HttpGet]
        //public IActionResult GetMoviesWithLikes(int likes)
        //{
        //    var teams = dbContext.Movies.Where(t => t.Likes >= likes).ToList();
        //    return Ok(teams);
        //}


    }
}
