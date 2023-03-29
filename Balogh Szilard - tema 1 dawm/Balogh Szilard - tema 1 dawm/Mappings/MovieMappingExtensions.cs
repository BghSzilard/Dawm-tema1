
using Balogh_Szilard___tema_1_dawm.DTOs;
using Balogh_Szilard___tema_1_dawm.Models;

namespace Balogh_Szilard___tema_1_dawm.Mappings
{
    public static class MovieMappingExtensions
    {
        public static MovieSummaryDTO? ToDTO(this Movie movie)
        {
            if (movie == null)
            {
                return null;
            }

            return new MovieSummaryDTO
            {
                Id = movie.Id,
                Title = movie.Title
            };
        }
        public static IEnumerable<MovieSummaryDTO?> ToDTOs(this IEnumerable<Movie> movies)
        {
            return movies.Select(m => m.ToDTO()).ToList();
        }
    }
}
