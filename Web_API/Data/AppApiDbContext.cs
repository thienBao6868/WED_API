using Microsoft.EntityFrameworkCore;
using Web_API.Models.Domain;

namespace Web_API.Data
{
    public class AppApiDbContext: DbContext
    {
        public AppApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
}
