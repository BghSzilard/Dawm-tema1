using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;

namespace Balogh_Szilard___tema_1_dawm.Data
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> contacts { get; set; }
    }
}
