using Balogh_Szilard___tema_1_dawm.Data;
using Balogh_Szilard___tema_1_dawm.DTOs;
using Balogh_Szilard___tema_1_dawm.Mappings;
using Balogh_Szilard___tema_1_dawm.Models;
using Microsoft.EntityFrameworkCore;

namespace Balogh_Szilard___tema_1_dawm.Services
{
    public class MoviesService
    {
        private readonly MoviesDbContext dbContext;

        public MoviesService(MoviesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<MovieSummaryDTO?>> GetAllMovies()
        {
            var movies = await dbContext.Movies.ToListAsync();
            return movies.ToSummaryDTOs().ToList();
        }
        public async Task<Movie?> GetMovie(Guid id)
        {
            return await dbContext.Movies.FindAsync(id);
        }

        public async Task<Movie> AddMovie(AddMovieRequest addMovieRequest)
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

            return movie;
        }

        public async Task<Movie?> UpdateMovie(Guid id, UpdateMovieRequest updateMovieRequest)
        {
            var movie = await dbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return null;
            }

            movie.Likes = updateMovieRequest.Likes;

            await dbContext.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie?> DeleteMovie(Guid id)
        {
            var movie = await dbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return null;
            }

            dbContext.Remove(movie);
            await dbContext.SaveChangesAsync();

            return movie;
        }
    }
}
