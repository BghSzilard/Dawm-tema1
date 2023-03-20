using Balogh_Szilard___tema_1_dawm.Models;
using Microsoft.EntityFrameworkCore;

namespace Balogh_Szilard___tema_1_dawm.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
