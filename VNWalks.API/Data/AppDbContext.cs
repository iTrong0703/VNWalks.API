using Microsoft.EntityFrameworkCore;
using VNWalks.API.Models.Domain;

namespace VNWalks.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
    }
}
